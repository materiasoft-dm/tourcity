using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TourCity.Common.Entities;
using TourCity.Web.Models.Accounts;

namespace TourCity.Web.Infrastructure
{
    public class AutomapperConfig
    {
        private static AutomapperConfig config = new AutomapperConfig();
        public static void Init()
        {
            config.Register();
        }

        public void Register()
        {
            AutoMapper.Mapper.Initialize(c =>
            {
                c.CreateMap<User, ApplicationUser>()
                    .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
                    .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                    .ForMember(x => x.UserName, y => y.MapFrom(z => z.Email))
                    .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                    .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                    .ForMember(x => x.PasswordHash, y => y.MapFrom(z => z.PasswordHash));

                c.CreateMap<ApplicationUser, User>()
                    .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
                    .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                    .ForMember(x => x.Email, y => y.MapFrom(z => z.UserName))
                    .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                    .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                    .ForMember(x => x.PasswordHash, y => y.MapFrom(z => z.PasswordHash));
            });
               
        }
    }
}