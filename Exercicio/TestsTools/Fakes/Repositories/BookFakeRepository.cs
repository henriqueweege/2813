using RoomBooking.Domain.DataAccess.Repositories.Contracts;
using RoomBooking.Domain.Entities;
using TestsTools.Fakes.Repositories.Base;

namespace TestsTools.Fakes.Repositories;

public class BookFakeRepository : BaseFakeRepository<Book>, IBookRepository
{
}
