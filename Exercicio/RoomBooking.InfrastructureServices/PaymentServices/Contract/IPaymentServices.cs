using RoomBooking.Entities.ValueObjects;

namespace RoomBooking.InfrastructureServices.PaymentServices.Contract;

public interface IPaymentServices
{
    public bool SendPaymentRequest(string customerEmail, CreditCard creditCard);
}
