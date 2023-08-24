﻿using RoomBooking.Domain.DataAccess.Repositories.Contracts;
using RoomBooking.Domain.Entities;
using TestsTools.Fakes.Repositories.Base;

namespace TestsTools.Fakes.Repositories;

public class CustomerFakeRepository : BaseFakeRepository<Customer>, ICustomerRepository
{
    public Customer? GetByEmail(string email)
        => Entities.FirstOrDefault(x => x.Email == email);
}
