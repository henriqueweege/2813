using Microsoft.EntityFrameworkCore;
using RoomBooking.Domain.Entities;
using RoomBooking.Repositories.Repositories;
using RoomBookinhg.Infrastructure.Data;

namespace Repositories_UnitTests;

public class RoomRepository_UnitTests : IDisposable
{
    private readonly RoomRepository _repository;
    private readonly DateTime _date;
    private readonly string _name;
    public RoomRepository_UnitTests()
    {
        var context = new RoomBookingContext(new DbContextOptionsBuilder());
        _repository = new RoomRepository(context);
        _name = "room name";
    }

    [Fact]
    public void GivenRoomWithValidInformation_ShouldSave()
    {
        //arrange
        var model = new RoomModel(_name) { Id = Guid.NewGuid() };

        //act
        var saved = _repository.Save(model);

        //assert
        Assert.NotNull(saved);

    }

    [Fact]
    public void GivenValidId_GetByIdShouldReturnEntity()
    {
        //arrange
        var id = Guid.NewGuid();
        var model = new RoomModel(_name) { Id = id };
        _repository.Save(model);

        //act
        var entity = _repository.GetById(id);

        //assert
        Assert.Equal(id, entity.Id);
    }

    [Fact]
    public void GivenValidInformation_UpdateShouldReturnUpdatedEntity()
    {
        //arrange
        var id = Guid.NewGuid();
        var model = new RoomModel(_name) { Id = id };
        _repository.Save(model);

        //act
        var newName = Guid.NewGuid().ToString();
        var updated = _repository.Update(model with { Name = newName });

        //assert
        var entity = _repository.GetById(id);
        Assert.NotNull(updated);
        Assert.Equal(id, entity.Id);
        Assert.DoesNotMatch(model.Name, entity.Name);
    }

    [Fact]
    public void GivenMoreThenOneEntitySaved_GetAllShouldShouldReturnMoreThanOne()
    {
        //arrange
        _repository.Save(new RoomModel(_name) { Id = Guid.NewGuid() });
        _repository.Save(new RoomModel(_name) { Id = Guid.NewGuid() });
        _repository.Save(new RoomModel(_name) { Id = Guid.NewGuid() });

        //act
        var entities = _repository.GetAll();

        //assert
        Assert.True(entities.Count() > 0);
    }

    [Fact]
    public void GivenCallToDelete_ShouldRemoveEntity()
    {
        //arrange
        var id = Guid.NewGuid();
        var model = new RoomModel(_name) { Id = Guid.NewGuid() };
        _repository.Save(model);

        //act
        var removed = _repository.Delete(model);

        //assert
        var entity = _repository.GetById(id);
        Assert.True(removed);
        Assert.Null(entity);
    }

    public void Dispose()
    {
        _repository.Dispose();
    }
}
