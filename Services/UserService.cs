using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Abgular_API.Model;
using Abgular_API.Helper;
using Abgular_API.DataBase;
using Abgular_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Timers;

namespace Abgular_API.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<UserModel> AuthenticateAsync(string email, string password)
        {
            try
            {
                var userEntity = await _applicationDbContext.UserEntities.FirstOrDefaultAsync(s => s.Email == email);
                if (userEntity == null)
                    return null;

                if (!Cryptography.VerifyHashedPassword(userEntity.Password, password))
                {
                    return null;
                }

                //var userModel = _mapper.Map<UserModel>(userEntity);
                var userModel = new UserModel
                {
                    Id = userEntity.Id,
                    Email = userEntity.Email,
                    FullName = userEntity.FullName,
                    Password = userEntity.Password
                };
               

                var tokenHandler = new JwtSecurityTokenHandler();
                string appSecret = "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING";
                var key = Encoding.ASCII.GetBytes(appSecret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.PrimarySid, userModel.Id.ToString()),
                    new Claim(ClaimTypes.Name, userModel.FullName)
                    }),
                    Expires = DateTime.UtcNow.AddSeconds(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                userModel.Token = tokenHandler.WriteToken(token);


                return userModel;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }


        public async Task<UserModel> CreateAsync(UserModel userModel)
        {
            try
            {
                var userEntity = new UserEntity()
                {
                    FullName = userModel.FullName,
                    Email = userModel.Email,
                    Password = Cryptography.HashPassword(userModel.Password)
                };

                await _applicationDbContext.UserEntities.AddAsync(userEntity);
                await _applicationDbContext.SaveChangesAsync();

                return userModel;
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
    }
}
