using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using Krop.Business.DependencyResolvers.Autofac;
using Krop.Business.Exceptions.Extensions;
using Krop.Business.Features.Categories.Validations;
using Krop.IOC.DependencyResolvers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

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

            builder.Services.AddDbContextRegistration();//DbContext
            builder.Services.AddAutoMapperRegistration();//AutoMapper
			builder.Services.AddBusinessRuleRegistration();//BusinessRules
			builder.Services.AddExceptionRegistration();//Exception
			builder.Services.AddFluentValidationRegistration();//Fluent Validation
			builder.Services.AddIdentityServiceRegistration();//Identity Service
			builder.Services.AddWebApiRegistration();//WebApi Service
			builder.Services.AddEmailRegistration();//EmailService

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            builder.Services.AddScoped<IUrlHelperFactory, UrlHelperFactory>();

            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

            app.ConfigureCustomExceptionMiddleWare();

            app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
