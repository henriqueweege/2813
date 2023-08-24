using Microsoft.EntityFrameworkCore;
using RoomBookinhg.Infrastructure.Data.Contracts;
using RoomBooking.Domain.Entities;
using Microsoft.Extensions.Options;

namespace RoomBookinhg.Infrastructure.Data;


public class RoomBookingContext : DbContext, IDataContext
{
    public RoomBookingContext(DbContextOptionsBuilder dbContextOptionsBuilder) : base(dbContextOptionsBuilder.Options) {}


    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        
        dbContextOptionsBuilder.UseInMemoryDatabase(databaseName: "inMemoryDb");
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Customer> Customers { get; set; }
}
