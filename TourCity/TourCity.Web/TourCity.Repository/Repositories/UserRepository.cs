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
    }
}
