using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uib.Mvc.Models
{
    public class Price
    {
        public DateTime CheckIn { get; set; }
        public int Nigths { get; set; }
        public decimal Pvp { get; set; }
        public string Board { get; set; }
    }
}