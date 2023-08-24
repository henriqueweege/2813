using RoomBooking.Entities.ValueObjects.Contracts;

namespace RoomBooking.Entities.ValueObjects;

public record CreditCard : IValueObject
{
    public string Number { get; set; }
    public string Holder { get; set; }
    public string Expiration { get; set; }
    public string Cvv { get; set; }
}
