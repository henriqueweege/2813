using Microsoft.EntityFrameworkCore;
using RoomBooking.Domain.DataAccess.Repositories;
using RoomBooking.Domain.Entities;
using RoomBookinhg.Infrastructure.Data;
using TestsTools.Fakes.Repositories;

namespace Repositories_UnitTests;

public class RoomFakeRepository_UnitTests
{
    private readonly RoomFakeRepository _repository;
    private readonly string _name;
    public RoomFakeRepository_UnitTests()
    {
        _repository = new RoomFakeRepository();
        _name = "original name";
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
        Assert.NotEqual(initialName.ToString(), entity.Name.ToString());
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

}
