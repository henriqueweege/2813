using Microsoft.EntityFrameworkCore;
using RoomBooking.Domain.DataAccess.Repositories.Base;
using RoomBooking.Domain.DataAccess.Repositories.Contracts;
using RoomBooking.Domain.Entities;
using RoomBookinhg.Infrastructure.Data;
using RoomBookinhg.Infrastructure.Data.Contracts;
using System.Linq;

namespace RoomBooking.Domain.DataAccess.Repositories;

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
        => _entity.Where(x=>x.RoomId == id && x.Date.Date == date.Date).Select(x=>x);
}
