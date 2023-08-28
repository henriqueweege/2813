using Microsoft.EntityFrameworkCore;
using RoomBooking.Entities.Entities;
using RoomBooking.Infrastructure.DataAccess.Context;
using RoomBooking.Infrastructure.DataAccess.Repositories;

namespace Repositories_UnitTests;

public class BookRepository_UnitTests : IDisposable
{
    private readonly BookRepository _repository;
    private readonly DateTime _date;
    private readonly string _email;
    public BookRepository_UnitTests()
    {
        var context = new RoomBookingContext(new DbContextOptionsBuilder());
        _repository = new BookRepository(context);
        _date = DateTime.Now;
        _email = "email@email.com";
    }

    [Fact]
    public void GivenBookWithValidInformation_ShouldSave()
    {
        //arrange
        var tosave = new Book(_email, Guid.NewGuid(), _date);
        //act
        var saved = _repository.Save(tosave);

        //assert
        Assert.NotNull(saved);

    }


    [Fact]
    public void GivenValidId_GetByRoomIdAndDateShouldReturnEntity()
    {
        //arrange
        var tosave = new Book(_email, Guid.NewGuid(), _date);
        var saved = _repository.Save(tosave);

        //act
        var entity = _repository.GetByRoomIdAndDate(saved.RoomId, saved.Date).ToList();

        //assert
        Assert.Equal(saved.Id, entity[0].Id);
    }

    [Fact]
    public void GivenValidId_GetByIdShouldReturnEntity()
    {
        //arrange
        var tosave = new Book(_email, Guid.NewGuid(), _date);
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
        var saved = _repository.Save(new Book(_email, Guid.NewGuid(), _date));
        var id = saved.Id;
        var initialRoomId = saved.RoomId;

        //act
        saved.ChangeRoomId(Guid.NewGuid());
        var updated = _repository.Update(saved);

        //assert
        var entity = _repository.GetById(id);
        Assert.NotNull(updated);
        Assert.Equal(id, entity.Id);
        Assert.NotEqual(initialRoomId.ToString(), entity.RoomId.ToString());
    }

    [Fact]
    public void GivenMoreThenOneEntitySaved_GetAllShouldShouldReturnMoreThanOne()
    {
        //arrange
        _repository.Save(new Book(_email, Guid.NewGuid(), _date));
        _repository.Save(new Book(_email, Guid.NewGuid(), _date));
        _repository.Save(new Book(_email, Guid.NewGuid(), _date));

        //act
        var entities = _repository.GetAll();

        //assert
        Assert.True(entities.Count() > 0);
    }

    [Fact]
    public void GivenCallToDelete_ShouldRemoveEntity()
    {
        //arrange
        var saved = _repository.Save(new Book(_email, Guid.NewGuid(), _date));
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
