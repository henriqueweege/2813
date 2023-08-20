using Microsoft.EntityFrameworkCore;
using RoomBooking.Domain.Entities;
using RoomBooking.Repositories.Repositories;
using RoomBookinhg.Infrastructure.Data;

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
		var model = new BookModel(_email, Guid.NewGuid(), _date) { Id = Guid.NewGuid()};

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
        var model = new BookModel(_email, Guid.NewGuid(), _date) { Id = id};
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
        var model = new BookModel(_email, Guid.NewGuid(), _date) { Id = id};
        _repository.Save(model);

        //act
        var newRoomId = Guid.NewGuid();
        var updated = _repository.Update(model with { Room = newRoomId });

        //assert
        var entity = _repository.GetById(id);
        Assert.NotNull(updated);
        Assert.Equal(id, entity.Id);
        Assert.DoesNotMatch(model.Room.ToString(), entity.Room.ToString());
    }

    [Fact]
    public void GivenMoreThenOneEntitySaved_GetAllShouldShouldReturnMoreThanOne()
    {
        //arrange
        _repository.Save(new BookModel(_email, Guid.NewGuid(), _date){Id = Guid.NewGuid()});
        _repository.Save(new BookModel(_email, Guid.NewGuid(), _date){Id = Guid.NewGuid()});
        _repository.Save(new BookModel(_email, Guid.NewGuid(), _date) { Id = Guid.NewGuid() });

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
        var model = new BookModel(_email, Guid.NewGuid(), _date) { Id = id };
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
