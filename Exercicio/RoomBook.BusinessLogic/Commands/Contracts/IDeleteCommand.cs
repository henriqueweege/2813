namespace RoomBooking.BusinessLogic.Commands.Contracts;

public interface IDeleteCommand
{
    public Guid Id { get; set; }
}
