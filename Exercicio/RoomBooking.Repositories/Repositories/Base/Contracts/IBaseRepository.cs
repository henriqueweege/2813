
using RoomBooking.Domain.Entities.Base;

namespace RoomBooking.Domain.Repositories.Base.Contracts;

public interface IBaseRepository<E> where E : Entity
{
    public E? Save(E model);
    public E? GetById(Guid id);
    public IEnumerable<E> GetAll();
    public E? Update(E model);
    public bool Delete(E id);
}
