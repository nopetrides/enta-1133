using System;
using UnityEngine;

public class RoomBase
{
    // todo make them all lambdo like north
    private RoomBase _north, _east, _south, _west;

    public RoomBase North => _north;
    public RoomBase East => _east;
    public RoomBase South => _south; 
    public RoomBase West => _west;

    private Vector2 _roomPosition;
    public Vector2 RoomPosition => _roomPosition;

    public RoomBase(Vector2 coordinates)
    {
        _roomPosition = coordinates;
        Console.WriteLine("Room " + _roomPosition + " Created!");
    }

    public void SetRooms(RoomBase roomNorth, RoomBase roomEast, RoomBase roomSouth, RoomBase roomWest)
    {
        _north = roomNorth;
        _east = roomEast;
        _south = roomSouth;
        _west = roomWest;
    }
}
