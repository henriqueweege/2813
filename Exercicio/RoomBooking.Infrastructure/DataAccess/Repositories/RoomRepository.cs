using RoomBooking.Entities.Entities;
using RoomBooking.Infrastructure.DataAccess.Data.Contracts;
using RoomBooking.Infrastructure.DataAccess.Repositories.Base;
using RoomBooking.Infrastructure.DataAccess.Repositories.Contracts;

namespace RoomBooking.Infrastructure.DataAccess.Repositories;
public class RoomRepository : BaseRepository<Room>, IRoomRepository
{
    public RoomRepository(IDataContext context) : base(context) { }
}
