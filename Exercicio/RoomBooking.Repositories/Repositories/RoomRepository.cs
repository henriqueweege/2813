using RoomBooking.Domain.Entities;
using RoomBooking.Domain.Repositories.Base;
using RoomBooking.Repositories.Repositories.Contracts;
using RoomBookinhg.Infrastructure.Data.Contracts;

namespace RoomBooking.Repositories.Repositories;
public class RoomRepository : BaseRepository<Room>, IRoomRepository
{
    public RoomRepository(IDataContext context) : base(context) { }
}
