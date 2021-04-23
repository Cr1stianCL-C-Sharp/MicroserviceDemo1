using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using VirtualMind.API.Config;
using VirtualMind.API.Filters;
using VirtualMind.Application.IServices;
using VirtualMind.Application.Mapper;
using VirtualMind.Application.Services;
using VirtualMind.Core.Context;
using VirtualMind.Infrastructure.IRepository;
using VirtualMind.Infrastructure.Repository;

namespace VirtualMind.API.Extensions
{
    public static class ExtensionServices
    {

        public static void ConfigureServices(this IServiceCollection services)
        {
            //services.AddControllers();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter()); //addes to suppornt enums on body request
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidatorFilter));
            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>()); //fluent validation added

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VirtualMind.API", Version = "v1" });
            });
            services.AddHttpClient();
        }


        public static void ConfigureContexts(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<VirtualMindAPPDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("VirtualMind.API"))); //add conection string to db context instance

        }


        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));//auto mapper instance
            // Auto Mapper Configurations  
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void ConfigureEndpoints(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection(nameof(EndpointsConfig)).Get<List<EndpointsConfig>>(); //added endpoint config
            services.AddSingleton(section);
        }


        public static void DependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<ICurrencyBuyValidationService, CurrencyBuyValidationService>();
            services.AddTransient<ICurrencyBuyService, CurrencyBuyService>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<ICurrencyBuyRepository, CurrencyBuyRepository>();

        }
    }
}
