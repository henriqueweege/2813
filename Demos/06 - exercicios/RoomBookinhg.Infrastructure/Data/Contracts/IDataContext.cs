using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RoomBookinhg.Infrastructure.Data.Contracts;

public interface IDataContext : IDisposable
{
    EntityEntry Entry(Object entity);
    DbSet<T> Set<T>() where T : class;
    Int32 SaveChanges();
}
