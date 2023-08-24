using RoomBooking.Entities.Entities.Base;
using RoomBooking.Infrastructure.DataAccess.Repositories.Base.Contracts;

namespace TestsTools.Fakes.Repositories.Base;

public class BaseFakeRepository<E> : IBaseRepository<E> where E : Entity
{
    internal IList<E> Entities { get; set; }
    public BaseFakeRepository()
    {
        Entities = new List<E>();
    }

    public bool Delete(E entity)
    {
        var toDelete = Entities.FirstOrDefault(e => e.Id == entity.Id);
        if (toDelete is not null)
        {
            Entities.Remove(toDelete);
            return true;
        }
        return false;
    }

    public IEnumerable<E> GetAll()
        => Entities.ToList();

    public E? GetById(Guid id)
        => Entities.FirstOrDefault(e => e.Id == id);

    public E? Save(E entity)
    {
        try
        {
            Entities.Add(entity);
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public E? Update(E entity)
    {
        try
        {
            var toUpdate = Entities.FirstOrDefault(e => e.Id == entity.Id);
            if (toUpdate is not null)
            {
                Entities.Remove(toUpdate);
                Entities.Add(entity);
                return entity;
            }
            return null;
        }
        catch
        {
            return null;
        }
    }
}
