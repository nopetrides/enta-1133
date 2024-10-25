using UnityEngine;

public class CombatRoom : RoomBase
{
    public override void SetRoomLocation(Vector2 coordinates)
    {
        base.SetRoomLocation(coordinates);
    }

    public override void OnRoomEntered()
    {
        Debug.Log("Combat Room Entered");
    }

    public override void OnRoomSearched()
    {
        Debug.Log("Combat Room Searched. Starting Combat!");
    }

    public override void OnRoomExited()
    {
        Debug.Log("Combat Room Exited");
    }

}
