using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using GtMotive.Estimate.Microservice.Api.Authorization;
using GtMotive.Estimate.Microservice.Api.DependencyInjection;
using GtMotive.Estimate.Microservice.Api.Filters;
using GtMotive.Estimate.Microservice.Api.UseCases.Rentals.RegisterRentals;
using GtMotive.Estimate.Microservice.Api.UseCases.Rentals.ReturnVehicles;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ListVehicles;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.RegisterVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ListVehicles;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.DateTimeProvider;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.Api
{
    [ExcludeFromCodeCoverage]
    public static class ApiConfiguration
    {
        public static void ConfigureControllers(MvcOptions options)
        {
            ArgumentNullException.ThrowIfNull(options);

            options.Filters.Add<BusinessExceptionFilter>();
        }

        public static IMvcBuilder WithApiControllers(this IMvcBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            builder.AddApplicationPart(typeof(ApiConfiguration).GetTypeInfo().Assembly);

            AddApiDependencies(builder.Services);

            return builder;
        }

        public static void AddApiDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>(); // from Infraestructure

            services.AddScoped<IVehicleRepository, VehicleRepository>(); // from Infraestructure

            services.AddScoped<IRegisterVehicleUseCase, RegisterVehicleUseCase>(); // from ApplicationCore
            services.AddScoped<IRegisterVehicleOutputPort, RegisterVehiclePresenter>(); // from API

            services.AddScoped<IListVehiclesUseCase, ListVehiclesUseCase>(); // from ApplicationCore
            services.AddScoped<IListVehiclesOutputPort, ListVehiclesPresenter>(); // from API

            services.AddScoped<IRentalRepository, RentalRepository>(); // from Infraestructure

            services.AddScoped<IRegisterRentalUseCase, RegisterRentalUseCase>(); // from ApplicationCore
            services.AddScoped<IRegisterRentalOutputPort, RegisterRentalPresenter>(); // from API

            services.AddScoped<IReturnVehicleUseCase, ReturnVehicleUseCase>(); // from ApplicationCore
            services.AddScoped<IReturnVehicleOutputPort, ReturnVehiclePresenter>(); // from API

            services.AddAuthorization(AuthorizationOptionsExtensions.Configure);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApiConfiguration).GetTypeInfo().Assembly));
            services.AddUseCases();
            services.AddPresenters();
        }
    }
}
