using RoomBooking.Domain.Entities.Base;

namespace RoomBooking.Domain.DataAccess.Repositories.Base.Contracts;

public interface IBaseRepository<E> where E : Entity
{
    public E? Save(E entity);
    public E? GetById(Guid id);
    public IEnumerable<E> GetAll();
    public E? Update(E entity);
    public bool Delete(E entity);
}
