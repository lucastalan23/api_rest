using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_rest.Domain.Models
{
    public class Category
    {
        public int IdCategory { get; set; }
        public String Name { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}

