using System;
namespace Enta_1133_Week6
{
	public class RoomBase
	{
		// todo make them all lambdo like north
		private RoomBase north, East, South, West;
		public RoomBase North => north;
		private int roomNumber;

		public RoomBase(int num)
		{
			roomNumber = num;
			Console.WriteLine("Room " + num + " Created!");
		}

		public void SetRooms(RoomBase roomToTheNorth, RoomBase east, RoomBase south, RoomBase west)
		{
			north = roomToTheNorth;
			East = east;
			South = south;
			West = west;
		} 
	}
}

