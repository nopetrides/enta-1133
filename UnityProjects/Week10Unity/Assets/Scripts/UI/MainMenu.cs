using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIManager UiSystem;
    [SerializeField] private InGameHud GameHud;

    public void ButtonStartGame()
    {
        UiSystem.ActivateInGameHud();
        GameHud.OnStartGame();
    }
}
