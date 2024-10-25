using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MapManager GameMapPrefab;

    private MapManager _gameMap;

    public void Start()
    {
        Debug.Log("GameManager Start");
        // zero our manager position
        transform.position = Vector3.zero;

        // create an instance of the map manager
        _gameMap = Instantiate(GameMapPrefab, transform);
        _gameMap.transform.position = Vector3.zero;
        // create the map
        _gameMap.CreateMap();

        Debug.Log("GameManager Map Created");

        StartGame();
    }

    private void StartGame()
    {
        // Intro
        Debug.Log("Hello, World!");
        var randomStartingRoom = _gameMap.Rooms.ElementAt(Random.Range(0, _gameMap.Rooms.Keys.Count));
        // Set the camera to the spawn room
        Camera.main.transform.position = new Vector3(randomStartingRoom.Key.x, 2.5f, randomStartingRoom.Key.y);
    }
}