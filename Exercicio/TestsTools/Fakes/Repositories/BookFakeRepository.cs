using RoomBooking.Entities.Entities;
using RoomBooking.Infrastructure.DataAccess.Repositories.Contracts;
using TestsTools.Fakes.Repositories.Base;

namespace TestsTools.Fakes.Repositories;

public class BookFakeRepository : BaseFakeRepository<Book>, IBookRepository
{
    public IQueryable<Book>? GetByRoomIdAndDate(Guid id, DateTime date)
        => Entities.Where(x => x.RoomId == id && x.Date.Date == date.Date).Select(x => x).AsQueryable();
}
