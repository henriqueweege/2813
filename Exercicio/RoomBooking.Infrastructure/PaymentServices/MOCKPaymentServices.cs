using RoomBooking.Domain.ValueObjects;
using RoomBooking.Infrastructure.PaymentServices.Contract;

namespace RoomBooking.Infrastructure.PaymentServices;

public class MOCKPaymentServices : IPaymentServices
{
    public bool SendPaymentRequest(string customerEmail, CreditCard creditCard)
        => true;
}
