using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Core.Entity
{
    public class Portfolio:BaseEntity
    {
        public Category Category { get; set; }
        public int CategoryId {  get; set; }


    }
}
