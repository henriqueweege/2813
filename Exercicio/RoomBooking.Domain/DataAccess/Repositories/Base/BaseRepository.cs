using Microsoft.EntityFrameworkCore;
using RoomBooking.Domain.DataAccess.Repositories.Base.Contracts;
using RoomBooking.Domain.Entities.Base;
using RoomBookinhg.Infrastructure.Data;
using RoomBookinhg.Infrastructure.Data.Contracts;

namespace RoomBooking.Domain.DataAccess.Repositories.Base;

public class BaseRepository<E> : IDisposable, IBaseRepository<E> where E : Entity
{
    private RoomBookingContext Context { get; set; }
    private DbSet<E> EntitySet { get; set; }
    public BaseRepository(IDataContext context)
    {
        Context = (RoomBookingContext)context;
        EntitySet = Context.Set<E>();
    }

    public IEnumerable<E> GetAll() => EntitySet.ToList();

    public E? GetById(Guid id) => EntitySet.FirstOrDefault(entity => entity.Id == id);

    public E? Save(E model)
    {
        Context.Add(model);
        if (Saved())
        {
            return model;
        }
        return null;
    }
    public E? Update(E model)
    {
        Context.Update(model);
        if (Saved())
        {
            return model;
        }
        return null;
    }
    public bool Delete(E model)
    {
        Context.Remove(model);
        return SaveChanges().Result > 0;
    }

    private bool Saved()
        => SaveChanges().Result > 0;


    public Task<int> SaveChanges() => Context.SaveChangesAsync();

    public void Dispose()
    {
        Context.Dispose();
    }

}
