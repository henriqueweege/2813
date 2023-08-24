using RoomBooking.Domain.ValueObjects;

namespace RoomBooking.InfrastructureServices.PaymentServices.Contract;

public interface IPaymentServices
{
    public bool SendPaymentRequest(string customerEmail, CreditCard creditCard);
}
