using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMailing.Models.Entities;
using WebMailing.Models.ViewModels;

namespace WebMailing.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
           


            CreateMap<User, CreateUser>().ReverseMap();

        }
    }
}
