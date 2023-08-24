using Domain.Commands;
using Domain.Commands.Contracts;
using Domain.Queries.Contracts;
using RoomBooking.Domain.Converters.Contracts;
using RoomBooking.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Domain.Handlers.Base;

public abstract class BaseHandler<E,
                         C,
                         CC,
                         UC,
                         DC,
                         GAQ,
                         GBIQ> where E : Entity
                               where CC : ICreateCommand
                               where UC : IUpdateCommand
                               where DC : IDeleteCommand
                               where GAQ : IGetAllQuery
                               where GBIQ : IGetByIdQuery
                               where C : class, IConverter<E, CC, UC>
{

    public abstract CommandResult<E> Handle(CC command);
}
