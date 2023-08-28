using Microsoft.EntityFrameworkCore;
using RoomBooking.Entities.Entities;
using RoomBooking.Infrastructure.DataAccess.Context.Contracts;

namespace RoomBooking.Infrastructure.DataAccess.Context;


public class RoomBookingContext : DbContext, IDataContext
{
    public RoomBookingContext(DbContextOptionsBuilder dbContextOptionsBuilder) : base(dbContextOptionsBuilder.Options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        dbContextOptionsBuilder.UseInMemoryDatabase(databaseName: "inMemoryDb");
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Customer> Customers { get; set; }
}
