using Dari.Domain.Entities;
using Dari.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Dari.Data.Infrastructure;

namespace Dari.Service
{
    public class CategorieService : Service<CategorieMeub>, ICategorieService

    {
        public CategorieService(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
