using MediatR;
using RoomBooking.Entities.Entities.Base;

namespace RoomBook.BusinessLogic.Commands;

public class CommandResult<E> : IRequest where E : Entity
{
    public E? Result { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public CommandResult()
    {

    }

    public CommandResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public CommandResult(bool success, string message, E entity)
    {
        Result = entity;
        Success = success;
        Message = message;
    }
}
