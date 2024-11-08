using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Layouts;

    private enum MenuLayouts
    {
        Main = 0,
        InGame = 1,
        Pause = 2,
        // Settings, etc
    }

    private void Start()
    {
        OpenMainMenu();
    }

    private void SetLayout(MenuLayouts layout)
    {
        for (int i = 0; i < Layouts.Length; i++)
        {
            Layouts[i].SetActive((int)layout == i);
        }
    }

    public void OpenMainMenu()
    {
        SetLayout(MenuLayouts.Main);
    }

    public void ActivateInGameHud()
    {
        SetLayout(MenuLayouts.InGame);
    }

    public void ShowPausegameMenu()
    {
        SetLayout(MenuLayouts.Pause);
    }

    // so on...
}
