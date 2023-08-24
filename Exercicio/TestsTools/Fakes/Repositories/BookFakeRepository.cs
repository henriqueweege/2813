using RoomBooking.Domain.DataAccess.Repositories.Contracts;
using RoomBooking.Domain.Entities;
using TestsTools.Fakes.Repositories.Base;

namespace TestsTools.Fakes.Repositories;

public class BookFakeRepository : BaseFakeRepository<Book>, IBookRepository
{
    public IQueryable<Book>? GetByRoomIdAndDate(Guid id, DateTime date)
        => Entities.Where(x => x.RoomId == id && x.Date.Date == date.Date).Select(x=>x).AsQueryable();
}
