using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RoomBooking.BusinessLogic.Commands.BookCommands;
using RoomBooking.BusinessLogic.Commands.CustomerCommands;
using RoomBooking.BusinessLogic.Commands.RoomCommands;
using RoomBooking.BusinessLogic.Converters;
using RoomBooking.BusinessLogic.Converters.Contracts;
using RoomBooking.Entities.Entities;
using RoomBooking.Infrastructure.DataAccess.Context;
using RoomBooking.Infrastructure.DataAccess.Context.Contracts;
using RoomBooking.Infrastructure.DataAccess.Repositories;
using RoomBooking.Infrastructure.DataAccess.Repositories.Contracts;
using RoomBooking.InfrastructureServices.PaymentServices;
using RoomBooking.InfrastructureServices.PaymentServices.Contract;
using System.Reflection;

namespace DependencyRoomBooking.Extensions;

#pragma warning disable 1591
public static class DependenciesExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {

        services.AddTransient<IBookRepository, BookRepository>();
        services.AddTransient<IRoomRepository, RoomRepository>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();
    }

    public static void AddConverters(this IServiceCollection services)
    {
        services.AddTransient<IConverter<Book, CreateBookCommand, UpdateBookCommand>, BookConverter>();
        services.AddTransient<IConverter<Room, CreateRoomCommand, UpdateRoomCommand>, RoomConverter>();
        services.AddTransient<IConverter<Customer, CreateCustomerCommand, UpdateCustomerCommand>, CustomerConverter>();
    }

    public static void AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<IDataContext, RoomBookingContext>();
        services.AddTransient<DbContextOptionsBuilder>();
    }

    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<IPaymentServices, MOCKPaymentServices>();
    }

    public static void AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateBookCommand).Assembly));
    }

    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {

            c.SwaggerDoc("v1", new OpenApiInfo
            {

                Version = "1.0.0",
                Title = "Dependency Room Booking",
            });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

        });
    }
}
