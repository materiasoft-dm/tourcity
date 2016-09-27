using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TourCity.Infrastructure.Mappers
{
    public class EntityMapperBootstrap
    {
        public static void Init()
        {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                foreach (Type interfaceType in type.GetInterfaces().Where(c => c == typeof(IEntityMapperBase)))
                {
                    var mapper = (IEntityMapperBase)Activator.CreateInstance(type);
                    mapper.Register();
                }
            }
        }
    }
}
