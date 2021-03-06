using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Domain.Helpers;

namespace api_rest.Domain.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public String Name { get; set; }
        public short QuantityInPackage { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        public int IdCategory { get; set; }
        public Category Category { get; set; }

    }
}
