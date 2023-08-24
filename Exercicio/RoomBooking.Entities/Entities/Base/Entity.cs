using System.ComponentModel.DataAnnotations;

namespace RoomBooking.Entities.Entities.Base;

public abstract class Entity
{
    [Key]
    public Guid Id { get; private set; }
    public Entity()
    {
        Id = Guid.NewGuid();
    }
}
