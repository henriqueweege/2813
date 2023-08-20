using RoomBooking.Domain.ValueObjects.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Domain.ValueObjects;

public record CreditCard(string Number, string Holder, string Expiration, string Cvv) : IValueObject;
