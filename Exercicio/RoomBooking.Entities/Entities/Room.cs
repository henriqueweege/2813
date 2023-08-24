using RoomBooking.Domain.Entities.Base;

namespace RoomBooking.Domain.Entities;

public class Room : Entity
{
    public string Name { get; private set; }
    public Room(string name)
    {
        Name = name;
    }

    #region Change Methods
    public bool ChangeName(string name)
    {
        Name = name;
        return true;
    }
    #endregion
}

