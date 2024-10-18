using System.Collections.Generic;
using UnityEngine;

public class Map
{
    /// <summary>
    /// Map is this number squared
    /// </summary>
    private const int MapSize = 9;
    readonly Dictionary<Vector2, RoomBase> _rooms = new ();

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
		for (int x = 0; x < MapSize; x++)
        {
            for (int z = 0; z < MapSize; z++)
            {
				Vector2 coords = new Vector2(x,z);
				_rooms.Add(coords, new RoomBase(coords));
			}
		}

        foreach (var roomByCoordinate in _rooms)
        {
            RoomBase northRoom = FindRoom(roomByCoordinate.Key, Direction.North);
            RoomBase eastRoom = FindRoom(roomByCoordinate.Key, Direction.East);
            RoomBase southRoom = FindRoom(roomByCoordinate.Key, Direction.South);
            RoomBase westRoom = FindRoom(roomByCoordinate.Key, Direction.West);

            roomByCoordinate.Value.SetRooms(northRoom, eastRoom, southRoom, westRoom);
        }
    }

    /// <summary>
    /// Visualize the map with some primitives
    /// </summary>
    private void VisualizeMap()
    {
		foreach(var roomByCoordinate in _rooms)
		{
			var mapRoomRepresentation = GameObject.CreatePrimitive(PrimitiveType.Cube);
            mapRoomRepresentation.transform.position = new Vector3(roomByCoordinate.Key.x, 0, roomByCoordinate.Key.y);
		}
    }
    /// <summary>
    /// Find the next room in a direction from an existing room
    /// </summary>
    /// <param name="currentRoom"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    private RoomBase FindRoom(Vector2 currentRoom, Direction direction)
    {
        RoomBase room = null;
        Vector2 nextRoomCoordinates = new Vector2(-1,-1);
        switch (direction)
        {
            case Direction.North:
                // Determine North Room
                nextRoomCoordinates = currentRoom + Vector2.up;
                break;
            case Direction.East:
                // east
                nextRoomCoordinates = currentRoom + Vector2.right;
                break;
            case Direction.South:
                // south
                nextRoomCoordinates = currentRoom + Vector2.down;
                break;
            case Direction.West:
                // west
                nextRoomCoordinates = currentRoom + Vector2.left;
                break;
        }
        
        if (_rooms.TryGetValue(nextRoomCoordinates, out var nextRoom))
        {
            room = nextRoom;
        }
        
        return room;
    }

}

