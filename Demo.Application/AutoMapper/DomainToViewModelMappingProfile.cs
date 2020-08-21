using AutoMapper;
using Demo.Application.ViewModels;
using Demo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Client, ClientViewModel>();
        }
    }
}
