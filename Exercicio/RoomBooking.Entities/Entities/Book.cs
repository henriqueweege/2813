using RoomBooking.Entities.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.Entities.Entities;

public class Book : Entity
{
    public string Email { get; private set; }
    public Guid RoomId { get; private set; }
    public DateTime Date { get; private set; }

    public Book(string email, Guid roomId, DateTime date)
    {
        Email = email;
        RoomId = roomId;
        Date = date;
    }

    #region Change Methods
    public bool ChangeEmail(string email)
    {
        var validator = new EmailAddressAttribute();
        if (validator.IsValid(email))
        {
            Email = email;
            return true;
        }
        return false;
    }
    public bool ChangeDate(DateTime date)
    {
        Date = date;
        return true;
    }
    public bool ChangeRoomId(Guid newRoomId)
    {
        RoomId = newRoomId;
        return true;
    }
    #endregion
}

