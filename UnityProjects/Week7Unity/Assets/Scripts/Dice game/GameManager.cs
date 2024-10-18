using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Map gameMap;

    public void Start()
    {
        Debug.Log("GameManager Start");

        gameMap = new Map();

        Debug.Log("GameManager Map Created");

        StartGame();

        Vector2 myVector = new Vector2(3, 4);
        float size = myVector.magnitude;
        Debug.Log($"This vector has a magnitude of {size}. That was easy!");

        /*
        System.Random rand = new System.Random();

        int playerPos = rand.Next(0, gameMap.MapSize);
        RoomBase current = gameMap.RoomByIndex(playerPos);

        // example moving north, setting the current room from current.North
        
        if (inputDir == 0 )
        {
            if (current.North != null)
            {
                current = current.North;
            }
        }
        */
    }

    public void StartGame()
    {
        // Intro
        Debug.Log("Hello, World!");
    }
}