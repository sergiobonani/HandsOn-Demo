using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Demo.Application.AutoMapper;
using Demo.Application.Interfaces;
using Demo.Application.Services;
using Demo.Application.Validation;
using Demo.Domain.Interfaces;
using Demo.Infra.Repositories;
using System;

namespace Demo.Infra.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddScoped<IClientService, ClientService>();

            services.AddScoped<ClientValidation>();

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
