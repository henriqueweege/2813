using Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Domain.Commands.Book;

public class DeleteBookCommand : IDeleteCommand
{
    public Guid Id { get; set; }
}
