using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uib.Mvc.Models
{
    public class Hotel
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public string Description{ get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Price Price { get; set; }
    }
}