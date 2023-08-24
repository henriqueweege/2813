using RoomBooking.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsTools.Fakes.InfrastructureServices;

namespace FakeInfrastructureServices_UnitTests.PaymentServices;

public class FakePaymentServices_UnitTests
{
    private readonly FakePaymentServices _paymentServices;
	public FakePaymentServices_UnitTests()
	{
		_paymentServices = new FakePaymentServices();
	}

	[Fact]
	public void GivenCallToSendPaymentRequest_ShouldReturnTrue()
	{
		//arrange
		var creditCard = new CreditCard()
		{
            Number = "number",
            Holder = "holder",
            Expiration = "expiration",
            Cvv = "cvv"
        };
		var email = "mail@email.com";

		//act-assert
		Assert.True(_paymentServices.SendPaymentRequest(email, creditCard));
	}
}
