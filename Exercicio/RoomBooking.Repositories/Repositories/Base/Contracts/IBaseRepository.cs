using RoomBooking.Domain.Entities.Contracts;

namespace RoomBooking.Domain.Repositories.Base.Contracts;

public interface IBaseRepository<M> where M : class, IModel
{
    public M? Save(M model);
    public M? GetById(Guid id);
    public IEnumerable<M> GetAll();
    public M? Update(M model);
    public bool Delete(M id);
}
