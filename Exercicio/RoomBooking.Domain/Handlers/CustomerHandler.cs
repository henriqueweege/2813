using RoomBooking.Domain.Commands.Customer;
using RoomBooking.Domain.Converters;
using RoomBooking.Domain.Converters.Contracts;
using RoomBooking.Domain.DataAccess.Repositories;
using RoomBooking.Domain.DataAccess.Repositories.Contracts;
using RoomBooking.Domain.Entities;
using RoomBooking.Domain.Handlers.Base;
using RoomBooking.Domain.Queries.Customer;

namespace RoomBooking.Domain.Handlers;

public class CustomerHandler : CRUDHandler<Customer, CustomerConverter, 
                                           CreateCustomerCommand, UpdateCustomerCommand, DeleteCustomerCommand,
                                           GetAllCustomerQuery, GetByIdCustomerQuery>
{


    public CustomerHandler(IConverter<Customer, CreateCustomerCommand, UpdateCustomerCommand> converter, ICustomerRepository repository) : base(converter, repository)
    {
    }

}
