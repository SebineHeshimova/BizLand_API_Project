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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(BizLandDbContext context) : base(context)
        {
        }
    }
}
