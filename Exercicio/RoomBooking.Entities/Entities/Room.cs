using RoomBooking.Entities.Entities.Base;

namespace RoomBooking.Entities.Entities;

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

