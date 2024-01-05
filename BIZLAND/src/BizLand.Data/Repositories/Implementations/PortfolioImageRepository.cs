using BizLand.Core.Entity;
using BizLand.Core.Repositories.Interfaces;
using BizLand.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Data.Repositories.Implementations
{
    public class PortfolioImageRepository : GenericRepository<PortfolioImage>, IPortfolioImageRepository
    {
        public PortfolioImageRepository(BizLandDbContext context) : base(context)
        {
        }
    }
}
