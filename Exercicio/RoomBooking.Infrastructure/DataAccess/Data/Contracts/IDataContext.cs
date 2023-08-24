using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RoomBooking.Infrastructure.DataAccess.Data.Contracts;

public interface IDataContext : IDisposable
{
    EntityEntry Entry(object entity);
    DbSet<T> Set<T>() where T : class;
    int SaveChanges();
}
