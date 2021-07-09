using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Domain.Helpers;
using api_rest.Domain.Models;

namespace api_rest.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        public int QuantityInPackage { get; set; }
        public Category Category { get; set;}

    }
}
