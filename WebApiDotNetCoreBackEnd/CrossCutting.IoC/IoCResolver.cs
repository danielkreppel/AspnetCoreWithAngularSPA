using AutoMapper;
using Common.AutoMapper;
using Common.Log.Concrete;
using Common.Log.Contract;
using Data.Concrete;
using Data.Contract;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Service.Concrete;
using Service.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Repository.Contract;
using Repository.Concrete;

namespace CrossCutting.IoC
{
    public static class IoCResolver
    {
        public static void Config(IServiceCollection services, IConfiguration configuration)
        {
            #region Configuring DI for AutoMapper
            var mapperconfig = AutoMapperConfig.RegisterMappings();
            services.AddSingleton(typeof(IMapper), mapperconfig.CreateMapper());
            #endregion

            #region  Configuring DI for connection factory 
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            #endregion

            #region Configuring DI from DBcontext (Entity Framework Core)
            services.AddDbContext<ApplicationDBContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DBconn")).UseLazyLoadingProxies(),
                ServiceLifetime.Scoped
            );
            #endregion

            #region Configuring DI for repositories (EF)
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Configuring DI for repositories (Dapper)
            //services.AddScoped<IAeronavesRepository, AeronavesRepository>();
            //services.AddScoped<ITiposAeronavesRepository, TiposAeronavesRepository>();
            //services.AddScoped<IAeroportosRepository, AeroportosRepository>();
            //services.AddScoped<IPlanoVooRepository, PlanoVooRepository>();
            #endregion

            #region Configuring DI for services
            services.AddScoped<IPlanoVooService, PlanoVooService>();
            services.AddScoped<IAeronaveService, AeronaveService>();
            services.AddScoped<IAeroportoService, AeroportoService>();
            services.AddScoped<IUsersService, UsersService>();
            #endregion

            #region Configurando DI para Log
            services.AddSingleton<ILog, Log>();
            #endregion
        }
    }
}
