using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussKollen.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Num { get; set; }
        public string Line { get; set; }
        public string CatOut { get; set; }
        public string CatIn { get; set; }
        public string CatCode { get; set; }
        public string CatOutS { get; set; }
        public string CatOutL { get; set; }
        public string OperatorCode { get; set; }
        public string Operator { get; set; }
        public string Admin { get; set; }
    }
}
