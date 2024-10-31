using UnityEngine;

public class TreasureRoom : RoomBase
{
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("Treasure Room Entered");
    }

    public override void OnRoomSearched()
    {
        Debug.Log("Treasure Room Searched. Rolling Loot!");
    }

    public override void OnRoomExited()
    {
        Debug.Log("Treasure Room Exited");
    }
}
