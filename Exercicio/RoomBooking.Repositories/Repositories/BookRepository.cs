using RoomBooking.Domain.Entities;
using RoomBooking.Domain.Repositories.Base;
using RoomBooking.Domain.Repositories.Contracts;
using RoomBookinhg.Infrastructure.Data.Contracts;

namespace RoomBooking.Repositories.Repositories;

public class BookRepository : BaseRepository<BookModel>, IBookRepository
{
    public BookRepository(IDataContext context) : base(context) { }
}
