using api_rest.Domain.Helpers;
using api_rest.Domain.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System;


namespace api_rest.Resources
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(30)]
        public string Name{ get; set; }
    }
}
