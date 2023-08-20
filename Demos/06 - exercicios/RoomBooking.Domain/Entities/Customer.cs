using RoomBooking.Domain.Entities.Contracts;
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.Domain.Entities;

public class Customer
{
}
public record CustomerModel(string Email) : IModel
{
    [Key]
    public Guid Id { get; init; }
}
