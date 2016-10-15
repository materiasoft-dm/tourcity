using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourCity.Common.Entities;

namespace TourCity.Repository.Repositories
{
    public class SpaceRepository : RepositoryBase<Space>
    {
        public SpaceRepository(DbContext context) : base(context)
        {
        }
    }
}
