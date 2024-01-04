using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Core.Entity
{
    public class PortfolioImage:BaseEntity
    {
        public Portfolio Portfolio { get; set; }
        public int PortfolioId { get; set; }
        public string ImageUrl {  get; set; }

    }
}
