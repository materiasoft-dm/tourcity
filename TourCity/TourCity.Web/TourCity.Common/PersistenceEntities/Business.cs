using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourCity.Common.Entities
{
    public class Business : EntityBase
    {
        public string BusinessName { get; set; }
        public int CategoryId { get; set; }

    }
}
