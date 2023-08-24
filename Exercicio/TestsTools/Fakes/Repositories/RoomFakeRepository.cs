using RoomBooking.Entities.Entities;
using RoomBooking.Infrastructure.DataAccess.Repositories.Contracts;
using TestsTools.Fakes.Repositories.Base;

namespace TestsTools.Fakes.Repositories;

public class RoomFakeRepository : BaseFakeRepository<Room>, IRoomRepository
{
}
