using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_2.Models;
using Vidly_2.Models.DTO;

namespace Vidly_2.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<CustomerModel, CustomerModelDTO>();
            Mapper.CreateMap<CustomerModelDTO, CustomerModel>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieModel, MovieModelDTO>();
            Mapper.CreateMap<MovieModelDTO, MovieModel>().ForMember(m => m.Id, opt => opt.Ignore());

        }
    }
}