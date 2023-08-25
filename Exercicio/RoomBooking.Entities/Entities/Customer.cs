using RoomBooking.Entities.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.Entities.Entities;

public class Customer : Entity
{
    public string Email { get; private set; }
    public Customer(string email)
    {
        ChangeEmail(email);
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
        throw new ArgumentException("Email em formato inválido.");
    }
    #endregion
}
