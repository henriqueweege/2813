using Microsoft.EntityFrameworkCore;
using RoomBooking.Domain.Entities;
using RoomBooking.Repositories.Repositories;
using RoomBookinhg.Infrastructure.Data;

namespace Repositories_UnitTests;

public class CustomerRepository_UnitTests : IDisposable
{
    private readonly CustomerRepository _repository;
    private readonly DateTime _date;
    private readonly string _email;
    public CustomerRepository_UnitTests()
    {
        var context = new RoomBookingContext(new DbContextOptionsBuilder());
        _repository = new CustomerRepository(context);
        _email = "mail@email.com";
    }

    [Fact]
    public void GivenRoomWithValidInformation_ShouldSave()
    {
        //arrange
        var model = new CustomerModel(_email) { Id = Guid.NewGuid() };

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
        var model = new CustomerModel(_email) { Id = id };
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
        var model = new CustomerModel(_email) { Id = id };
        _repository.Save(model);

        //act
        var newName = Guid.NewGuid().ToString();
        var updated = _repository.Update(model with { Email = newName });

        //assert
        var entity = _repository.GetById(id);
        Assert.NotNull(updated);
        Assert.Equal(id, entity.Id);
        Assert.DoesNotMatch(model.Email, entity.Email);
    }

    [Fact]
    public void GivenMoreThenOneEntitySaved_GetAllShouldShouldReturnMoreThanOne()
    {
        //arrange
        _repository.Save(new CustomerModel(_email) { Id = Guid.NewGuid() });
        _repository.Save(new CustomerModel(_email) { Id = Guid.NewGuid() });
        _repository.Save(new CustomerModel(_email) { Id = Guid.NewGuid() });

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
        var model = new CustomerModel(_email) { Id = Guid.NewGuid() };
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
