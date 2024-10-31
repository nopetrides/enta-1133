using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MapManager GameMapPrefab;
    [SerializeField] private PlayerController PlayerPrefab;

    private MapManager _gameMap;
    private PlayerController _playerController;

    public void Start()
    {
        Debug.Log("GameManager Start Begins");
        // zero our manager's position
        transform.position = Vector3.zero;
        SetupMap();
        SpawnPlayer();
        StartGame();
        Debug.Log("GameManager Start Complete");
    }

    private void SetupMap()
    {
        Debug.Log("GameManager SetupMap Begins");
        // create an instance of the map manager
        _gameMap = Instantiate(GameMapPrefab, transform);
        _gameMap.transform.position = Vector3.zero;
        // create the map
        _gameMap.CreateMap();
        Debug.Log("GameManager Setup Complete");
    }

    private void SpawnPlayer()
    {
        // Intro
        Debug.Log("GameManager SpawnPlayer Begins");
        // Pick a random starting room - this must be done only after the map is created
        var randomStartingRoom = _gameMap.Rooms.ElementAt(Random.Range(0, _gameMap.Rooms.Keys.Count));
        // Create the player
        _playerController = Instantiate(PlayerPrefab, transform);
        // Set their initial position
        _playerController.transform.position = new Vector3(randomStartingRoom.Key.x, 0, randomStartingRoom.Key.y);
        // Call the Player Setup Function
        _playerController.Setup();
        Debug.Log("GameManager SpawnPlayer Complete");
    }

    private void StartGame()
    {
        Debug.Log("GameManager StartGame Begins");
        Debug.Log("GameManager StartGame Complete");
    }

}