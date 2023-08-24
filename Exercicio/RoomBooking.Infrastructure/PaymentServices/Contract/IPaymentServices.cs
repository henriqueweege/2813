using RoomBooking.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Infrastructure.PaymentServices.Contract;

public interface IPaymentServices
{
    public bool SendPaymentRequest(string customerEmail, CreditCard creditCard); 
}
