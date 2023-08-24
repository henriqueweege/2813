using RoomBooking.Entities.ValueObjects;
using RoomBooking.InfrastructureServices.PaymentServices.Contract;

namespace RoomBooking.InfrastructureServices.PaymentServices;

public class MOCKPaymentServices : IPaymentServices
{
    public bool SendPaymentRequest(string customerEmail, CreditCard creditCard)
        => true;
}
