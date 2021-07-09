using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_rest.Resources
{
    public class TokenResource
    {
        public string Login { get; set; }
        public string password { get; set; }
    }
}
