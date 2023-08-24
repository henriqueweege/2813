using MediatR;
using RoomBook.BusinessLogic.Commands;
using RoomBook.BusinessLogic.Commands.CustomerCommands;
using RoomBook.BusinessLogic.Converters;
using RoomBook.BusinessLogic.Converters.Contracts;
using RoomBook.BusinessLogic.Handlers.Base;
using RoomBook.BusinessLogic.Queries;
using RoomBook.BusinessLogic.Queries.CustomerQueries;
using RoomBooking.Entities.Entities;
using RoomBooking.Infrastructure.DataAccess.Repositories.Contracts;

namespace RoomBook.BusinessLogic.Handlers;

public class CustomerHandler : CRUDHandler<Customer, CustomerConverter,
                                           CreateCustomerCommand, UpdateCustomerCommand, DeleteCustomerCommand,
                                           GetAllCustomerQuery, GetByIdCustomerQuery>,
                           IRequestHandler<UpdateCustomerCommand, CommandResult<Customer>>,
                           IRequestHandler<CreateCustomerCommand, CommandResult<Customer>>,
                           IRequestHandler<DeleteCustomerCommand, CommandResult<Customer>>,
                           IRequestHandler<GetAllCustomerQuery, QueryResult<Customer>>,
                           IRequestHandler<GetByIdCustomerQuery, QueryResult<Customer>>
{


    public CustomerHandler(IConverter<Customer, CreateCustomerCommand, UpdateCustomerCommand> converter, ICustomerRepository repository) : base(converter, repository){ }

    public Task<CommandResult<Customer>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        => Task.FromResult(Handle(request));

    public Task<CommandResult<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        => Task.FromResult(Handle(request));

    public Task<CommandResult<Customer>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        => Task.FromResult(Handle(request));

    public Task<QueryResult<Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        => Task.FromResult(Handle(request));

    public Task<QueryResult<Customer>> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        => Task.FromResult(Handle(request));
}
