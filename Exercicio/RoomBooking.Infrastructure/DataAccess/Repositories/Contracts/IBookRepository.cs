using RoomBooking.Entities.Entities;
using RoomBooking.Infrastructure.DataAccess.Repositories.Base.Contracts;

namespace RoomBooking.Infrastructure.DataAccess.Repositories.Contracts;

public interface IBookRepository : IBaseRepository<Book>
{
    public IQueryable<Book>? GetByRoomIdAndDate(Guid id, DateTime date);
}
