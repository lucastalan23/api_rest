using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_rest.Resources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(12)]
        public string Login { get; set; }

        [Required]
        [MaxLength(15)]
        public string Password { get; set; }
    }
}
