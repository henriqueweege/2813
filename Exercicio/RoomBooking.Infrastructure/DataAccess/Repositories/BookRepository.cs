using Microsoft.EntityFrameworkCore;
using RoomBooking.Entities.Entities;
using RoomBooking.Infrastructure.DataAccess.Data.Contracts;
using RoomBooking.Infrastructure.DataAccess.Repositories.Base;
using RoomBooking.Infrastructure.DataAccess.Repositories.Contracts;

namespace RoomBooking.Infrastructure.DataAccess.Repositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{

    private readonly IDataContext _context;
    private readonly DbSet<Book> _entity;
    public BookRepository(IDataContext context) : base(context)
    {
        _context = context;
        _entity = _context.Set<Book>();
    }

    public IQueryable<Book>? GetByRoomIdAndDate(Guid id, DateTime date)
        => _entity.Where(x => x.RoomId == id && x.Date.Date == date.Date).Select(x => x);
}
