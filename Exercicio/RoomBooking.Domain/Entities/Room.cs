using RoomBooking.Domain.Entities.Contracts;
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.Domain.Entities;

public class Room
{
}
public record RoomModel(string Name) : IModel
{
    [Key]
    public Guid Id { get; init; }
}
