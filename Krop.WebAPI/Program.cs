using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Krop.Business.DependencyResolvers.Autofac;
using Krop.Business.Exceptions.Extensions;
using Krop.Business.Exceptions.Middlewares;
using Krop.Business.Exceptions.Middlewares.Transaction;
using Krop.Common.Helpers.CacheHelpers;
using Krop.Common.Helpers.JwtService;
using Krop.Common.Utilits.Caching;
using Krop.Common.Utilits.Caching.Redis;
using Krop.DataAccess.UnitOfWork;
using Krop.IOC.DependencyResolvers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Krop.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddRepositoryServiceRegistration();
            builder.Services.AddDbContextRegistration();//DbContext
            builder.Services.AddAutoMapperRegistration();//AutoMapper
            builder.Services.AddBusinessRuleRegistration();//BusinessRules
            builder.Services.AddFluentValidationRegistration();//Fluent Validation
            builder.Services.AddIdentityServiceRegistration();//Identity Service
            builder.Services.AddWebApiRegistration();//WebApi Service
            builder.Services.AddEmailRegistration();//EmailService

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IJwtService, JwtService>();
            
            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            builder.Services.AddScoped<IUrlHelperFactory, UrlHelperFactory>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = builder.Configuration["TokenOptions:Issuer"],
                    ValidAudience = builder.Configuration["TokenOptions:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenOptions:SecurityKey"])),
                };
            });
            builder.Services.AddStackExchangeRedisCache(options => options.Configuration = "localhost:1453");
            builder.Services.AddSingleton<ICacheService, DistributedCacheManager>();
            builder.Services.AddSingleton<ICacheHelper,CacheHelper>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.ConfigureCustomExceptionMiddleWare();
            app.UseMiddleware<TransactionMiddleware>();
            app.UseMiddleware<AuthorizationMiddleware>();
            
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
