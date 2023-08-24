using RoomBooking.Entities.Entities;
using TestsTools.Fakes.Repositories;

namespace FakeRepositories_UnitTests;

public class BookFakeRepository_UnitTests
{
    private readonly BookFakeRepository _repository;
    private readonly string _email;
    private readonly Guid _roomId;
    private readonly DateTime _date;
    public BookFakeRepository_UnitTests()
    {
        _repository = new BookFakeRepository();
        _email = "mail@email.com";
        _roomId = Guid.NewGuid();
        _date = DateTime.UtcNow;
    }

    [Fact]
    public void GivenBookWithValidInformation_ShouldSave()
    {
        //arrange
        var tosave = new Book(_email, _roomId, _date);
        //act
        var saved = _repository.Save(tosave);

        //assert
        Assert.NotNull(saved);

    }

    [Fact]
    public void GivenValidId_GetByIdShouldReturnEntity()
    {
        //arrange
        var tosave = new Book(_email, _roomId, _date);
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
        var saved = _repository.Save(new Book(_email, _roomId, _date));
        var id = saved.Id;
        var initialEmail = saved.Email;
        var initialRoomId = saved.RoomId;
        var initialDate = saved.Date;

        //act
        saved.ChangeEmail("newmail@email.com");
        saved.ChangeRoomId(Guid.NewGuid());
        saved.ChangeDate(DateTime.Now.AddDays(1.0));
        var updated = _repository.Update(saved);

        //assert
        var entity = _repository.GetById(id);
        Assert.NotNull(updated);
        Assert.Equal(id, entity.Id);
        Assert.NotEqual(initialEmail.ToString(), entity.Email.ToString());
        Assert.NotEqual(initialRoomId.ToString(), entity.RoomId.ToString());
        Assert.NotEqual(initialDate.ToString(), entity.Date.ToString());
    }

    [Fact]
    public void GivenMoreThenOneEntitySaved_GetAllShouldShouldReturnMoreThanOne()
    {
        //arrange
        _repository.Save(new Book(_email, _roomId, _date));
        _repository.Save(new Book(_email, _roomId, _date));
        _repository.Save(new Book(_email, _roomId, _date));

        //act
        var entities = _repository.GetAll();

        //assert
        Assert.True(entities.Count() > 0);
    }

    [Fact]
    public void GivenCallToDelete_ShouldRemoveEntity()
    {
        //arrange
        var saved = _repository.Save(new Book(_email, _roomId, _date));
        var id = saved.Id;

        //act
        var removed = _repository.Delete(saved);

        //assert
        var entity = _repository.GetById(id);
        Assert.True(removed);
        Assert.Null(entity);
    }

}
