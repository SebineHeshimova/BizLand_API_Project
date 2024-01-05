using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Core.Entity
{
    public class Slider:BaseEntity
    {
        public string Title1 {  get; set; }
        public string Title2 { get; set; }
        public string Description { get; set; }
        public string Button1Text {  get; set; }
        public string Button1Url {  get; set; }
        public string Button2Text {  get; set; }
        public string Button2Url { get; set;}
    }
}
