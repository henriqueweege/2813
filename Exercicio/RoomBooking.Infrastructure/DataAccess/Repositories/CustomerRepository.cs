using Microsoft.EntityFrameworkCore;
using RoomBooking.Domain.DataAccess.Repositories.Base;
using RoomBooking.Domain.DataAccess.Repositories.Contracts;
using RoomBooking.Domain.Entities;
using RoomBookinhg.Infrastructure.Data.Contracts;
using System.Data;

namespace RoomBooking.Domain.DataAccess.Repositories;

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
