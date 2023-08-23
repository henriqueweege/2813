using RoomBooking.Domain.DataAccess.Repositories.Base;
using RoomBooking.Domain.DataAccess.Repositories.Contracts;
using RoomBooking.Domain.Entities;
using RoomBookinhg.Infrastructure.Data;
using RoomBookinhg.Infrastructure.Data.Contracts;

namespace RoomBooking.Domain.DataAccess.Repositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(IDataContext context) : base(context)
    {
    }
}
