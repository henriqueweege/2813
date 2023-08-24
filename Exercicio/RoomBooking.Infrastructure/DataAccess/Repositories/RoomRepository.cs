using RoomBooking.Domain.DataAccess.Repositories.Base;
using RoomBooking.Domain.DataAccess.Repositories.Contracts;
using RoomBooking.Domain.Entities;
using RoomBookinhg.Infrastructure.Data.Contracts;

namespace RoomBooking.Domain.DataAccess.Repositories;
public class RoomRepository : BaseRepository<Room>, IRoomRepository
{
    public RoomRepository(IDataContext context) : base(context) { }
}
