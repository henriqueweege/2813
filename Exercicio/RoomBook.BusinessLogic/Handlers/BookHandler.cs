using Domain.Commands;
using Domain.Enums;
using RoomBook.BusinessLogic.Commands.Book;
using RoomBook.BusinessLogic.Handlers.Base;
using RoomBooking.Domain.Commands.Book;
using RoomBooking.Domain.Converters;
using RoomBooking.Domain.Converters.Contracts;
using RoomBooking.Domain.DataAccess.Repositories.Contracts;
using RoomBooking.Domain.Entities;
using RoomBooking.Domain.Enums;
using RoomBooking.Domain.Enums.Extensions;
using RoomBooking.Domain.Queries.Book;
using RoomBooking.InfrastructureServices.PaymentServices.Contract;
using System;

namespace RoomBooking.Domain.Handlers;

public class BookHandler : CRUDHandler<Book, BookConverter,
                                           CreateBookCommand, UpdateBookCommand, DeleteBookCommand,
                                           GetAllBookQuery, GetByIdBookQuery>
{
    private readonly IBookRepository _bookRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IPaymentServices _paymentServices;


    public BookHandler(IConverter<Book, CreateBookCommand, UpdateBookCommand> converter, 
                       IBookRepository bookRepository,
                       ICustomerRepository customerRepository, IPaymentServices paymentServices) : base(converter, bookRepository)
    {
        _bookRepository = bookRepository;
        _customerRepository = customerRepository;
        _paymentServices = paymentServices;
    }

    public override CommandResult<Book> Handle(CreateBookCommand command)
    {
        try
        {
            //Recupera o usuário
            var customer = _customerRepository.GetByEmail(command.Email);

            if (customer is null)
                return new CommandResult<Book>(false, EErrorMessages.BAD_REQUEST_INVALID_EMAIL.GetDescription());

            // Verifica se a sala está disponível
            var room = _bookRepository.GetByRoomIdAndDate(command.RoomId, command.Day);

            // Se existe uma reserva, a sala está indisponível
            if (room.Any())
                return new CommandResult<Book>(false, EErrorMessages.BAD_REQUEST_OCCUPIED_ROOM.GetDescription());

            // Tenta fazer um pagamento
            var successPayment = _paymentServices.SendPaymentRequest(command.Email, command.CreditCard);

            // Se o pagamento não for realizado com sucesso
            if (!successPayment)
                return new CommandResult<Book>(false, EErrorMessages.BAD_REQUEST_OCCUPIED_ROOM.GetDescription());

            // Cria a reserva
            var book = new Book(command.Email, command.RoomId, command.Day);
            book = _bookRepository.Save(book);

            return new CommandResult<Book>(true, ESuccessMessages.OK_REQUISITON_COMPLETED_SUCCESSFULLY.GetDescription(), book);
        }
        catch (Exception ex)
        {
            return new CommandResult<Book>(false, ex.InnerException.Message);
        }

    }

}
