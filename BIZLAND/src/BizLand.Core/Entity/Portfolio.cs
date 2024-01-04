using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Core.Entity
{
    public class Portfolio:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string ProjectDate { get; set; }
        public string ProjectURL { get; set; }
        public List<PortfolioImage> Images { get; set; }
        public Category Category { get; set; }
        public int CategoryId {  get; set; }
        public string ImageUrl {  get; set; }

    }
}
