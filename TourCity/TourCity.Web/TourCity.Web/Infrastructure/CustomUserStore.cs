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
    public class CustomUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>
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
                var domainUser = AutoMapper.Mapper.Map<User>(user);
                _repo.Create(domainUser);
                _repo.SaveChanges();
            });

        }

        public Task UpdateAsync(ApplicationUser user)
        {
            return Task.Run(() =>
            {
                var domainUser = _repo.Retrieve(int.Parse(user.Id));
                domainUser = AutoMapper.Mapper.Map<User>(user);
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
            var user = AutoMapper.Mapper.Map<ApplicationUser>(domainUser);

            return Task.FromResult(user);
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            var domainUser = _repo.FindByName(userName);
            if (domainUser == null) return null;

            var user = AutoMapper.Mapper.Map<ApplicationUser>(domainUser);

            return Task.FromResult(user);
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }
        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            return Task.FromResult<string>(user.PasswordHash);
        }
        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            return Task.FromResult<bool>(!String.IsNullOrEmpty(user.Password));
        }
    }
}