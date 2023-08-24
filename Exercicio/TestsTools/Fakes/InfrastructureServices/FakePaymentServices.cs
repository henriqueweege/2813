using RoomBooking.Entities.ValueObjects;
using RoomBooking.InfrastructureServices.PaymentServices.Contract;

namespace TestsTools.Fakes.InfrastructureServices;

public class FakePaymentServices : IPaymentServices
{
    public bool SendPaymentRequest(string customerEmail, CreditCard creditCard)
        => true;
}
