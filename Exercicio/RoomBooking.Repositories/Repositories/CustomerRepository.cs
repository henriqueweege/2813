using RoomBooking.Domain.Entities;
using RoomBooking.Domain.Repositories.Base;
using RoomBooking.Domain.Repositories.Contracts;
using RoomBookinhg.Infrastructure.Data.Contracts;

namespace RoomBooking.Repositories.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(IDataContext context) : base(context) { }
}
