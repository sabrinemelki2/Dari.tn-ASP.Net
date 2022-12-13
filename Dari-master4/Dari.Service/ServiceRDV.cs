using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dari.Domain.Entities;
using Dari.Data.Infrastructure;

namespace Dari.Service
{
    public class ServiceRDV : Service<RDV>, IServiceRDV
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public ServiceRDV() : base(Uok)
        {

        }


    }
}
