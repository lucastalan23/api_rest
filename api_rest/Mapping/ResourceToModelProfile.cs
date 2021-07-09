using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_rest.Domain.Models;
using api_rest.Resources;
using AutoMapper;

namespace api_rest.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveProductResource, Product>();
            CreateMap<SaveUserResource, User>();
            CreateMap<TokenResource, User>();
        }
    }
}
