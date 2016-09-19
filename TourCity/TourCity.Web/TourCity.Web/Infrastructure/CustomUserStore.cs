using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using TourCity.Common.Entities;
using TourCity.Repository;
using TourCity.Repository.Repositories;
using TourCity.Web.Models.Accounts;

namespace TourCity.Web.Infrastructure
{
    public class CustomUserStore : IUserStore<ApplicationUser>
    {
        private UserRepository _repo;
        public CustomUserStore()
        {
                var context = new TourCityDbContext();
            _repo = new UserRepository(context);
        }
        public void Dispose()
        {
            _repo.Dispose();
        }

        public Task CreateAsync(ApplicationUser user)
        {
            return Task.Run(() =>
            {
                var domainUser = new User();
                domainUser.Email = user.UserName;
                domainUser.Password = user.Password;
                _repo.Create(domainUser);
                _repo.SaveChanges();
            });

        }

        public Task UpdateAsync(ApplicationUser user)
        {
            return Task.Run(() =>
            {
                var domainUser = _repo.Retrieve(int.Parse(user.Id));
                domainUser.Email = user.UserName;
                domainUser.Password = user.Password;
                _repo.SaveChanges();
            });
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            return Task.Run(() =>
            {
                var domainUser = _repo.Retrieve(int.Parse(user.Id));
              _repo.HardDelete(domainUser);
                _repo.SaveChanges();
            });
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            var domainUser = _repo.Retrieve(int.Parse(userId));
            var user = new ApplicationUser();
            user.Id = domainUser.Id.ToString();
            user.Password = domainUser.Password;
            user.UserName = domainUser.Email;

            return Task.FromResult(user);
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}