using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RoomBooking.Domain.Entities.Base;
using RoomBooking.Domain.Repositories.Base.Contracts;
using RoomBookinhg.Infrastructure.Data;
using RoomBookinhg.Infrastructure.Data.Contracts;

namespace RoomBooking.Domain.Repositories.Base;

public class BaseRepository<E> : IDisposable, IBaseRepository<E> where E : Entity
{
    private RoomBookingContext Context { get; set; }
    private DbSet<E> EntitySet { get;set; }
    public BaseRepository(IDataContext context)
    {
        Context = (RoomBookingContext)context;
        EntitySet = Context.Set<E>();
    }
    public bool Delete(E model) 
    {
        Context.Remove(model);
        return SaveChanges().Result > 0;
    }  

    public IEnumerable<E> GetAll() => EntitySet.ToList();

    public E? GetById(Guid id) => EntitySet.FirstOrDefault(entity => entity.Id == id);

    public E? Save(E model)
    {
        Context.Add(model);
        if (Saved())
        {
            Context.Entry(model).State = EntityState.Detached;
            return model;
        }
        return null;
    }
    public E? Update(E model)
    {
        Context.Update(model);
        if (Saved())
        {
            Context.Entry(model).State = EntityState.Detached;
            return model;
        }
        return null;
    }

    private bool Saved()
        => SaveChanges().Result > 0;
    

    public Task<int> SaveChanges() => Context.SaveChangesAsync();

    public void Dispose()
    {
        Context.Dispose();
    }
}
