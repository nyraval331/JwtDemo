using Abgular_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abgular_API.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> CreateAsync(UserModel userModel);

        Task<UserModel> AuthenticateAsync(string username, string password);
    }
}
