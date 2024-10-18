using UnityEngine;

public class Map
{
    /// <summary>
    /// Map is this number squared
    /// </summary>
    int mapSize = 9;
    public int MapSize => mapSize;
    RoomBase[] Rooms;

    public Map()
    {
        CreateMap();
        VisualizeMap();
    }

    /// <summary>
    /// Week 6 code
    /// </summary>
    private void CreateMap()
    {
        Rooms = new RoomBase[mapSize * mapSize];
        for (int i = 0; i < Rooms.Length; i++)
        {
            // todo Random 
            Rooms[i] = new RoomBase(i);
        }

        RoomBase currentRoom;

        for (int i = 0; i < Rooms.Length; i++)
        {
            currentRoom = Rooms[i];

            // example how to loop through all Directions
            /*
            foreach(Direction dir in Enum.GetValues(typeof(Direction)))
            {
                RoomBase nextRooom = FindRoom(i, dir);
            }*/
            RoomBase northRoom = FindRoom(i, Direction.North);
            RoomBase eastRoom = FindRoom(i, Direction.East);
            RoomBase southRoom = FindRoom(i, Direction.South);
            RoomBase westRoom = FindRoom(i, Direction.West);

            currentRoom.SetRooms(northRoom, eastRoom, southRoom, westRoom);
        }
    }

    /// <summary>
    /// Visualize the map with some primitives
    /// </summary>
    private void VisualizeMap()
    {
        for (int x = 0; x < mapSize; x++)
        {
            for (int z = 0; z < mapSize; z++)
            {
                // using primitives for now, will replace next week
                var mapRoomRepresentation = GameObject.CreatePrimitive(PrimitiveType.Cube);
                mapRoomRepresentation.transform.position = new Vector3(x, 0, z);
            }
        }
    }

    public RoomBase FindRoom(int currentRoom, Direction direction)
    {
        RoomBase room = null!;
        switch (direction)
        {
            case Direction.North:
                // Determine North Room
                int northRoomIndex = currentRoom - mapSize;
                if (northRoomIndex >= 0)
                {
                    room = Rooms[northRoomIndex];
                }
                break;
            case Direction.East:
                // east
                break;
            case Direction.South:
                // south
                break;
            case Direction.West:
                // west
                break;

        }
        return room;
    }

    public RoomBase RoomByIndex(int index)
    {
        return Rooms[index];
    }
}

