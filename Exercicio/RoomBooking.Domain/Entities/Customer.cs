using RoomBooking.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.Domain.Entities;

public class Customer : Entity
{
    public string Email { get; private set; }
    public Customer(string email)
    {
        Email = email;
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
    #endregion
}
