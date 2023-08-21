using RoomBooking.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.Domain.Entities;

public class Room : Entity
{
    public string Name { get; private set; }
    public Room(string name)
    {
        Name = name;
    }

    public bool ChangeName(string name)
    {
        Name = name;
        return true;
    }
}

