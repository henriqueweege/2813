using RoomBooking.BusinessLogic.Commands;
using RoomBooking.BusinessLogic.Commands.Contracts;
using RoomBooking.BusinessLogic.Converters.Contracts;
using RoomBooking.BusinessLogic.Enums;
using RoomBooking.BusinessLogic.Enums.Extensions;
using RoomBooking.BusinessLogic.Queries;
using RoomBooking.BusinessLogic.Queries.Contracts;
using RoomBooking.Entities.Entities.Base;
using RoomBooking.Infrastructure.DataAccess.Repositories.Base.Contracts;

namespace RoomBooking.BusinessLogic.Handlers.Base;

public class CRUDHandler<E, C, CC, UC, DC, GAQ, GBIQ>
             : BaseHandler<E, C, CC, UC, DC, GAQ, GBIQ>
             where E : Entity
             where C : class, IConverter<E, CC, UC>
             where CC : ICreateCommand
             where UC : IUpdateCommand
             where DC : IDeleteCommand
             where GAQ : IGetAllQuery
             where GBIQ : IGetByIdQuery
{
    private static IConverter<E, CC, UC> Converter { get; set; }
    private static IBaseRepository<E> Repository { get; set; }
    public CRUDHandler(IConverter<E, CC, UC> converter, IBaseRepository<E> repository)
    {
        Converter = converter;
        Repository = repository;
    }

    public override CommandResult<E> Handle(CC command)
    {
        try
        {
            var entity = Converter.ConvertFromCreateCommandToEntity(command);
            var resultCreate = Repository.Save(entity);

            if (resultCreate is null)
            {
                return new CommandResult<E>(false, EErrorMessages.INTERNAL_SERVER_ERROR.GetDescription(), entity);
            }
            return new CommandResult<E>(true, ESuccessMessages.OK_REQUISITON_COMPLETED_SUCCESSFULLY.GetDescription(), entity);
        }
        catch (ArgumentException ex)
        {
            return new CommandResult<E>(false, $"BadRequest: {ex.Message}");
        }
        catch (Exception ex)
        {
            return new CommandResult<E>(false, ex.InnerException.Message);
        }

    }

    public override CommandResult<E> Handle(UC command)
    {
        try
        {
            var entityToUpdate = Repository.GetById(command.Id);

            if (entityToUpdate is null)
            {
                return new CommandResult<E>(false, EErrorMessages.BAD_REQUEST.GetDescription());
            }

            entityToUpdate = Converter.ConvertFromUpdateCommandToEntity(command, entityToUpdate);
            var resultCreate = Repository.Update(entityToUpdate);

            if (resultCreate is not null)
            {
                return new CommandResult<E>(true, ESuccessMessages.OK_REQUISITON_COMPLETED_SUCCESSFULLY.GetDescription(), entityToUpdate);
            }
            return new CommandResult<E>(false, EErrorMessages.INTERNAL_SERVER_ERROR.GetDescription(), entityToUpdate);
        }
        catch (ArgumentException ex)
        {
            return new CommandResult<E>(false, $"BadRequest: {ex.Message}");
        }
        catch (Exception ex)
        {
            return new CommandResult<E>(false, ex.InnerException.Message);
        }

    }

    public CommandResult<E> Handle(DC command)
    {
        try
        {
            var entityToDelete = Repository.GetById(command.Id);

            if (entityToDelete is null)
            {
                return new CommandResult<E>(true, EErrorMessages.BAD_REQUEST.GetDescription());
            }

            var deleted = Repository.Delete(entityToDelete);

            if (deleted)
            {
                return new CommandResult<E>(true, ESuccessMessages.NO_CONTENT_REQUISITON_COMPLETED_SUCCESSFULLY.GetDescription());
            }
            return new CommandResult<E>(false, EErrorMessages.INTERNAL_SERVER_ERROR.GetDescription());

        }
        catch (Exception ex)
        {
            return new CommandResult<E>(false, ex.InnerException.Message);
        }
    }

    public QueryResult<E> Handle(GAQ query)
    {
        try
        {
            var entities = Repository.GetAll();

            if (entities != null && entities.Count() > 0)
            {
                return new QueryResult<E>(true, ESuccessMessages.OK_REQUISITON_COMPLETED_SUCCESSFULLY.GetDescription(), entities);
            }
            else
            {
                return new QueryResult<E>(true, ESuccessMessages.NO_CONTENT_REQUISITON_COMPLETED_SUCCESSFULLY.GetDescription(), entities);
            }
        }
        catch (Exception ex)

        {
            return new QueryResult<E>(false, ex.InnerException.Message);
        }
    }

    public QueryResult<E> Handle(GBIQ query)
    {
        try
        {
            var entities = Repository.GetById(query.Id);
            if (entities != null)
            {
                return new QueryResult<E>(true, ESuccessMessages.OK_REQUISITON_COMPLETED_SUCCESSFULLY.GetDescription(), entities);
            }
            else
            {
                return new QueryResult<E>(true, ESuccessMessages.NO_CONTENT_REQUISITON_COMPLETED_SUCCESSFULLY.GetDescription(), entities);
            }
        }
        catch (Exception ex)
        {
            return new QueryResult<E>(false, ex.InnerException.Message);
        }
    }
}
