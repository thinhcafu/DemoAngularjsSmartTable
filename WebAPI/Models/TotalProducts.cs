using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class TotalProducts
    {
        public int NumberProducts { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}