using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Map _gameMap;

    public void Start()
    {
        Debug.Log("GameManager Start");

        _gameMap = new Map();

        Debug.Log("GameManager Map Created");

        StartGame();
    }

    private void StartGame()
    {
        // Intro
        Debug.Log("Hello, World!");
    }
}