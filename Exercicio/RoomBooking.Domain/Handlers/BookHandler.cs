using Domain.Commands;
using Domain.Enums;
using RoomBooking.Domain.Commands.Book;
using RoomBooking.Domain.Converters;
using RoomBooking.Domain.Converters.Contracts;
using RoomBooking.Domain.DataAccess.Repositories.Contracts;
using RoomBooking.Domain.Entities;
using RoomBooking.Domain.Enums;
using RoomBooking.Domain.Enums.Extensions;
using RoomBooking.Domain.Handlers.Base;
using RoomBooking.Domain.Queries.Book;
using System;

namespace RoomBooking.Domain.Handlers;

public class BookHandler : CRUDHandler<Book, BookConverter,
                                           CreateBookCommand, UpdateBookCommand, DeleteBookCommand,
                                           GetAllBookQuery, GetByIdBookQuery>
{


    public BookHandler(IConverter<Book, CreateBookCommand, UpdateBookCommand> converter, IBookRepository repository) : base(converter, repository)
    {
    }

    public override CommandResult<Book> Handle(CreateBookCommand command)
    {
        try
        {
            var entity = new Book("", Guid.NewGuid(), DateTime.Now);
            return new CommandResult<Book>(true, ESuccessMessages.OK_REQUISITON_COMPLETED_SUCCESSFULLY.GetDescription(), entity);
        }
        catch (Exception ex)
        {
            return new CommandResult<Book>(false, ex.InnerException.Message);
        }

    }

}
