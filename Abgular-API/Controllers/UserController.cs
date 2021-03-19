using Abgular_API.DataTransferObjects;
using Abgular_API.Model;
using Abgular_API.Services;
using Abgular_API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abgular_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IConfiguration _config;
        private readonly IUserService _userService;

        public UserController(IConfiguration config, IUserService userService, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
            _userService = userService;

        }

        [HttpGet]
        public string GetRandomToken()
        {
            var jwt = new JwtServices(_config);
            var token = jwt.GenerateSecurityToken("fake@email.com");
            return token;
        }

        // POST: api/User
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateNewUser user)
        {
            try
            {
                if (user.Password == null)
                {
                    user.Password = Guid.NewGuid().ToString();
                }

                var userModel = _mapper.Map<UserModel>(user);
                userModel = await _userService.CreateAsync(userModel);
                var authenticatedUserModel = await _userService.AuthenticateAsync(user.Email, user.Password);
                var authenticatedUserDto = new AuthenticatedUser()
                {
                    Id = userModel.Id,
                    Email = authenticatedUserModel.Email,
                    Token = authenticatedUserModel.Token

                };
                var auditActionResult = new AuditActionResult<AuthenticatedUser>
                {
                    Object = authenticatedUserDto
                };

                return Ok(auditActionResult);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Authenticate model)
        {
            var user = await _userService.AuthenticateAsync(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var authenticatedUser = new AuthenticatedUser()
            {
                Email = user.Email,
                Token = user.Token
            };

            var auditActionResult = new AuditActionResult<AuthenticatedUser>
            {
                Object = authenticatedUser
            };

            return Ok(auditActionResult);
        }
    }
}
