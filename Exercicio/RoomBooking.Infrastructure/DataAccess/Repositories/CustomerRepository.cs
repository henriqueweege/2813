using Microsoft.EntityFrameworkCore;
using RoomBooking.Entities.Entities;
using RoomBooking.Infrastructure.DataAccess.Context.Contracts;
using RoomBooking.Infrastructure.DataAccess.Repositories.Base;
using RoomBooking.Infrastructure.DataAccess.Repositories.Contracts;

namespace RoomBooking.Infrastructure.DataAccess.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    private readonly IDataContext _context;
    private readonly DbSet<Customer> _entity;
    public CustomerRepository(IDataContext context) : base(context)
    {
        _context = context;
        _entity = _context.Set<Customer>();
    }

    public Customer? GetByEmail(string email)
        => _entity.FirstOrDefault(x => x.Email == email);
}
