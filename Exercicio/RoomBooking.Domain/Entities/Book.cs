using RoomBooking.Domain.Entities.Contracts;
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.Domain.Entities;

public class Book
{
}
public record BookModel(string Email, Guid Room, DateTime Date) : IModel
{
    [Key]
    public Guid Id { get; init; }
}
