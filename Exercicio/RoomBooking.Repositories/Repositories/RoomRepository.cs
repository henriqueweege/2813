using RoomBooking.Domain.Entities;
using RoomBooking.Domain.Repositories.Base;
using RoomBooking.Domain.Repositories.Contracts;
using RoomBookinhg.Infrastructure.Data.Contracts;

namespace RoomBooking.Repositories.Repositories;

public class RoomRepository : BaseRepository<RoomModel>, IRoomRepository
{
    public RoomRepository(IDataContext context) : base(context) { }
}
