using MediatR;
using RoomBooking.BusinessLogic.Commands;
using RoomBooking.BusinessLogic.Commands.RoomCommands;
using RoomBooking.BusinessLogic.Converters;
using RoomBooking.BusinessLogic.Converters.Contracts;
using RoomBooking.BusinessLogic.Handlers.Base;
using RoomBooking.BusinessLogic.Queries;
using RoomBooking.BusinessLogic.Queries.RoomQueries;
using RoomBooking.Entities.Entities;
using RoomBooking.Infrastructure.DataAccess.Repositories.Contracts;

namespace RoomBooking.BusinessLogic.Handlers;

public class RoomHandler : CRUDHandler<Room, RoomConverter,
                                       CreateRoomCommand, UpdateRoomCommand, DeleteRoomCommand,
                                       GetAllRoomQuery, GetByIdRoomQuery>,
                           IRequestHandler<UpdateRoomCommand, CommandResult<Room>>,
                           IRequestHandler<CreateRoomCommand, CommandResult<Room>>,
                           IRequestHandler<DeleteRoomCommand, CommandResult<Room>>,
                           IRequestHandler<GetAllRoomQuery, QueryResult<Room>>,
                           IRequestHandler<GetByIdRoomQuery, QueryResult<Room>>
{


    public RoomHandler(IConverter<Room, CreateRoomCommand, UpdateRoomCommand> converter, IRoomRepository repository) : base(converter, repository) { }

    public Task<CommandResult<Room>> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        => Task.FromResult(Handle(request));

    public Task<CommandResult<Room>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        => Task.FromResult(Handle(request));

    public Task<CommandResult<Room>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        => Task.FromResult(Handle(request));

    public Task<QueryResult<Room>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
        => Task.FromResult(Handle(request));

    public Task<QueryResult<Room>> Handle(GetByIdRoomQuery request, CancellationToken cancellationToken)
        => Task.FromResult(Handle(request));
}
