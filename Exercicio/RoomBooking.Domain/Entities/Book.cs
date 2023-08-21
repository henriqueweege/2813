using RoomBooking.Domain.Entities.Base;

namespace RoomBooking.Domain.Entities;

public class Book : Entity
{
    public Book(string email, Guid roomId, DateTime date)
    {
        Email = email;
        RoomId = roomId;
        Date = date;
    }

    public string  Email { get; private set; }
    public Guid RoomId { get; private set; }
    public DateTime Date { get; private set; }


    public bool ChangeRoomId(Guid newRoomId)
    {
        RoomId = newRoomId;
        return true;
    }
}

