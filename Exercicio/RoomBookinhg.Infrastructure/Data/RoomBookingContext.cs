using Microsoft.EntityFrameworkCore;
using RoomBookinhg.Infrastructure.Data.Contracts;
using RoomBooking.Domain.Entities;

namespace RoomBookinhg.Infrastructure.Data;


public class RoomBookingContext : DbContext, IDataContext
{
    public RoomBookingContext(DbContextOptionsBuilder dbContextOptionsBuilder) : base(dbContextOptionsBuilder.Options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        dbContextOptionsBuilder.UseInMemoryDatabase(databaseName: "inMemoryDb");

    }
    public DbSet<BookModel> BookModels { get; set; }
    public DbSet<RoomModel> RoomModels { get; set; }
    public DbSet<CustomerModel> CustomerModels { get; set; }
}
