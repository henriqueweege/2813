﻿using RoomBooking.Entities.Entities;
using TestsTools.Fakes.Repositories;

namespace FakeRepositories_UnitTests;

public class CustomerFakeRepository_UnitTests
{
    private readonly CustomerFakeRepository _repository;
    private readonly string _email;
    public CustomerFakeRepository_UnitTests()
    {
        _repository = new CustomerFakeRepository();
        _email = "mail@email.com";
    }

    [Fact]
    public void GivenBookWithValidInformation_ShouldSave()
    {
        //arrange
        var tosave = new Customer(_email);
        //act
        var saved = _repository.Save(tosave);

        //assert
        Assert.NotNull(saved);

    }

    [Fact]
    public void GivenValidId_GetByIdShouldReturnEntity()
    {
        //arrange
        var tosave = new Customer(_email);
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
        var saved = _repository.Save(new Customer(_email));
        var id = saved.Id;
        var initialEmail = saved.Email;

        //act
        saved.ChangeEmail("newmail@email.com");
        var updated = _repository.Update(saved);

        //assert
        var entity = _repository.GetById(id);
        Assert.NotNull(updated);
        Assert.Equal(id, entity.Id);
        Assert.NotEqual(initialEmail.ToString(), entity.Email.ToString());
    }

    [Fact]
    public void GivenMoreThenOneEntitySaved_GetAllShouldShouldReturnMoreThanOne()
    {
        //arrange
        _repository.Save(new Customer(_email));
        _repository.Save(new Customer(_email));
        _repository.Save(new Customer(_email));

        //act
        var entities = _repository.GetAll();

        //assert
        Assert.True(entities.Count() > 0);
    }

    [Fact]
    public void GivenCallToDelete_ShouldRemoveEntity()
    {
        //arrange
        var saved = _repository.Save(new Customer(_email));
        var id = saved.Id;

        //act
        var removed = _repository.Delete(saved);

        //assert
        var entity = _repository.GetById(id);
        Assert.True(removed);
        Assert.Null(entity);
    }

}
