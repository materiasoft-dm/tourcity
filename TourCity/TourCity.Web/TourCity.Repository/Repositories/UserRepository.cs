using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourCity.Common.Entities;

namespace TourCity.Repository.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
       
        public UserRepository(DbContext context):base(context)
        {

        }

        public User FindByName(string username)
        {
            return
                base._entities.FirstOrDefault(c => c.Email.Equals(username, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
