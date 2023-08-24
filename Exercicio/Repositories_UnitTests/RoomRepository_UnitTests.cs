using Microsoft.EntityFrameworkCore;
using RoomBooking.Entities.Entities;
using RoomBooking.Infrastructure.DataAccess.Data;
using RoomBooking.Infrastructure.DataAccess.Repositories;

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
    public void GivenBookWithValidInformation_ShouldSave()
    {
        //arrange
        var tosave = new Room(_name);
        //act
        var saved = _repository.Save(tosave);

        //assert
        Assert.NotNull(saved);

    }

    [Fact]
    public void GivenValidId_GetByIdShouldReturnEntity()
    {
        //arrange
        var tosave = new Room(_name);
        var saved = _repository.Save(tosave);

        //act
        var entity = _repository.GetById(saved.Id);

        //assert
        Assert.Equal(saved.Id, entity.Id);
    }

    [Fact]
    public void GivenValidInformation_UpdateShouldReturnUpdatedEntity()
    {
        //arrange
        var saved = _repository.Save(new Room(_name));
        var id = saved.Id;
        var initialName = saved.Name;

        //act
        saved.ChangeName("newmail@email.com");
        var updated = _repository.Update(saved);

        //assert
        var entity = _repository.GetById(id);
        Assert.NotNull(updated);
        Assert.Equal(id, entity.Id);
        Assert.DoesNotMatch(initialName.ToString(), entity.Name.ToString());
    }

    [Fact]
    public void GivenMoreThenOneEntitySaved_GetAllShouldShouldReturnMoreThanOne()
    {
        //arrange
        _repository.Save(new Room(_name));
        _repository.Save(new Room(_name));
        _repository.Save(new Room(_name));

        //act
        var entities = _repository.GetAll();

        //assert
        Assert.True(entities.Count() > 0);
    }

    [Fact]
    public void GivenCallToDelete_ShouldRemoveEntity()
    {
        //arrange
        var saved = _repository.Save(new Room(_name));
        var id = saved.Id;

        //act
        var removed = _repository.Delete(saved);

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
