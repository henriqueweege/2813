using MediatR;
using RoomBooking.BusinessLogic.Commands;
using RoomBooking.BusinessLogic.Commands.BookCommands;
using RoomBooking.BusinessLogic.Converters;
using RoomBooking.BusinessLogic.Converters.Contracts;
using RoomBooking.BusinessLogic.Enums;
using RoomBooking.BusinessLogic.Enums.Extensions;
using RoomBooking.BusinessLogic.Handlers.Base;
using RoomBooking.BusinessLogic.Queries;
using RoomBooking.BusinessLogic.Queries.BookQueries;
using RoomBooking.Entities.Entities;
using RoomBooking.Infrastructure.DataAccess.Repositories.Contracts;
using RoomBooking.InfrastructureServices.PaymentServices.Contract;

namespace RoomBooking.BusinessLogic.Handlers;

public class BookHandler : CRUDHandler<Book, BookConverter,
                                           CreateBookCommand, UpdateBookCommand, DeleteBookCommand,
                                           GetAllBookQuery, GetByIdBookQuery>,
                           IRequestHandler<UpdateBookCommand, CommandResult<Book>>,
                           IRequestHandler<CreateBookCommand, CommandResult<Book>>,
                           IRequestHandler<DeleteBookCommand, CommandResult<Book>>,
                           IRequestHandler<GetAllBookQuery, QueryResult<Book>>,
                           IRequestHandler<GetByIdBookQuery, QueryResult<Book>>

{
    private readonly IBookRepository _bookRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IPaymentServices _paymentServices;


    public BookHandler(IConverter<Book, CreateBookCommand, UpdateBookCommand> converter,
                       IBookRepository bookRepository,
                       ICustomerRepository customerRepository,
                       IRoomRepository roomRepository,
                       IPaymentServices paymentServices) : base(converter, bookRepository)
    {
        _bookRepository = bookRepository;
        _customerRepository = customerRepository;
        _roomRepository = roomRepository;
        _paymentServices = paymentServices;
    }

    public override CommandResult<Book> Handle(CreateBookCommand command)
    {
        try
        {
            var customerValidated = ValidateCustomer(command.Email);

            if (customerValidated is not null)
                return customerValidated;

            var bookAndRoomValidated = ValidateBookAndRoom(command.RoomId, command.Day);

            if (bookAndRoomValidated is not null)
                return bookAndRoomValidated;

            // Tenta fazer um pagamento
            var successPayment = _paymentServices.SendPaymentRequest(command.Email, command.CreditCard);

            // Se o pagamento não for realizado com sucesso
            if (!successPayment)
                return new CommandResult<Book>(false, EErrorMessages.BAD_REQUEST_OCCUPIED_ROOM.GetDescription());

            // Cria a reserva
            return base.Handle(command);
        }
        catch (Exception ex)
        {
            return new CommandResult<Book>(false, ex.InnerException.Message);
        }

    }

    private CommandResult<Book>? ValidateCustomer(string email)
    {
        // Verifica se cliente existe
        var customer = _customerRepository.GetByEmail(email);

        if (customer is null)
            return new CommandResult<Book>(false, EErrorMessages.BAD_REQUEST_INVALID_EMAIL.GetDescription());

        return null;
    }

    private CommandResult<Book>? ValidateBookAndRoom(Guid roomId, DateTime date)
    {
        // Verifica se a sala está disponível
        var books = _bookRepository.GetByRoomIdAndDate(roomId, date);

        // Se existe uma reserva, a sala está indisponível
        if (books.Any())
            return new CommandResult<Book>(false, EErrorMessages.BAD_REQUEST_OCCUPIED_ROOM.GetDescription());

        // Verifica se a sala existe
        var room = _roomRepository.GetById(roomId);

        // Se quarto não existe, retorna erro
        if (room is null)
            return new CommandResult<Book>(false, EErrorMessages.BAD_REQUEST_ROOM_DOESNOTEXIST.GetDescription());

        return null;
    }



    public override CommandResult<Book> Handle(UpdateBookCommand command)
    {
        try
        {
            var customerValidated = ValidateCustomer(command.Email);
            if (customerValidated is not null)
                return customerValidated;

            var bookAndRoomAreValid = ValidateBookAndRoom(command.RoomId, command.Day);
            if (bookAndRoomAreValid is not null)
                return bookAndRoomAreValid;

            return base.Handle(command);
        }
        catch (ArgumentException ex)
        {
            return new CommandResult<Book>(false, $"BadRequest: {ex.Message}");
        }
        catch (Exception ex)
        {
            return new CommandResult<Book>(false, ex.InnerException.Message);
        }

    }

    public Task<CommandResult<Book>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        => Task.FromResult(Handle(request));

    public Task<CommandResult<Book>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        => Task.FromResult(Handle(request));

    public Task<CommandResult<Book>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        => Task.FromResult(Handle(request));

    public Task<QueryResult<Book>> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
        => Task.FromResult(Handle(request));

    public Task<QueryResult<Book>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        => Task.FromResult(Handle(request));
}
