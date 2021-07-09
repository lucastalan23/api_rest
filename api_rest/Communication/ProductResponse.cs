using api_rest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_rest.Communication
{
    public class ProductResponse : BaseResponse
    {

        public Product Product { get; private set; }

        private ProductResponse(bool success, string Message, Product product) : base(success, Message)
        {
            Product = product;
        }

        public ProductResponse(Product product) : this(true, string.Empty, product)
        {
        }

        public ProductResponse(string Message) : this(false, Message, null) { }

    }
}
