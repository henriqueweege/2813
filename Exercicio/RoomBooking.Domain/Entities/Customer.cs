using RoomBooking.Domain.Entities.Base;

namespace RoomBooking.Domain.Entities;

public class Customer : Entity
{
    public string Email { get; private set; }
    public Customer(string email)
    {
        Email = email;
    }

    public bool ChangeEmail(string email)
    {
        Email= email;
        return true;
    }
}
