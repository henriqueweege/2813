using RoomBook.BusinessLogic.Commands;
using RoomBook.BusinessLogic.Commands.Contracts;
using RoomBook.BusinessLogic.Converters.Contracts;
using RoomBook.BusinessLogic.Queries.Contracts;
using RoomBooking.Entities.Entities.Base;

namespace RoomBook.BusinessLogic.Handlers.Base;

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
    public abstract CommandResult<E> Handle(UC command);
}
