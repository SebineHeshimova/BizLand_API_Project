using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Core.Entity
{
    public class Employee:BaseEntity
    {
        public string FullName {  get; set; }
        public Profession Profession { get; set; }
        public int ProfessionId {  get; set; }
        public string? ImageUrl {  get; set; }
        public string TwitterUrl {  get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedInUrl { get; set; }
    }
}
