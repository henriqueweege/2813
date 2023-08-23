using RoomBooking.Domain.DataAccess.Repositories.Contracts;
using RoomBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsTools.Fakes.Repositories.Base;

namespace TestsTools.Fakes.Repositories;

public class RoomFakeRepository : BaseFakeRepository<Room>, IRoomRepository
{
}
