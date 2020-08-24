using AutoMapper;
using Demo.Application.ViewModels;
using Demo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClientViewModel, Client>();
            CreateMap<AddressViewModel, Address>();
        }
    }
}
