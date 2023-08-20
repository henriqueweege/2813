using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RoomBooking.Domain.Entities.Contracts;
using RoomBooking.Domain.Repositories.Base.Contracts;
using RoomBookinhg.Infrastructure.Data;
using RoomBookinhg.Infrastructure.Data.Contracts;

namespace RoomBooking.Domain.Repositories.Base;

public class BaseRepository<M> : IDisposable, IBaseRepository<M> where M : class, IModel
{
    private RoomBookingContext Context { get; set; }
    private DbSet<M> EntitySet { get;set; }
    public BaseRepository(IDataContext context)
    {
        Context = (RoomBookingContext)context;
        EntitySet = Context.Set<M>();
    }
    public bool Delete(M model) 
    {
        Context.Remove(model);
        return SaveChanges().Result > 0;
    }  

    public IEnumerable<M> GetAll() => EntitySet.ToList();

    public M? GetById(Guid id) => EntitySet.FirstOrDefault(entity => entity.Id == id);

    public M? Save(M model)
    {
        Context.Add(model);
        if (Saved())
        {
            Context.Entry(model).State = EntityState.Detached;
            return model;
        }
        return null;
    }
    public M? Update(M model)
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
