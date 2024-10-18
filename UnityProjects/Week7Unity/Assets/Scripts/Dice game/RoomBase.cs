using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBase
{
    // todo make them all lambdo like north
    private RoomBase north, east, south, west;

    public RoomBase North => north;
    public RoomBase East => east;
    public RoomBase South => south; 
    public RoomBase West1 => west;

    private int roomNumber;

    public RoomBase(int num)
    {
        roomNumber = num;
        Console.WriteLine("Room " + num + " Created!");
    }

    public void SetRooms(RoomBase roomNorth, RoomBase roomEast, RoomBase roomSouth, RoomBase roomWest)
    {
        north = roomNorth;
        east = roomEast;
        south = roomSouth;
        west = roomWest;
    }
}
