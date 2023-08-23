using RoomBooking.Domain.DataAccess.Repositories.Base;
using RoomBooking.Domain.DataAccess.Repositories.Contracts;
using RoomBooking.Domain.Entities;
using RoomBookinhg.Infrastructure.Data.Contracts;

namespace RoomBooking.Domain.DataAccess.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(IDataContext context) : base(context) { }
}
