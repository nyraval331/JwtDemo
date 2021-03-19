using Abgular_API.DataBase.Entities;
using Abgular_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Abgular_API.DataTransferObjects;

namespace Abgular_API.Helper
{
    public class CustomMapperProfile : Profile
    {
        public CustomMapperProfile()
        {
            CreateMap<DataBase.Entities.UserEntity, UserModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<CreateNewUser, UserModel>();
        }

    }
}
