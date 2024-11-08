using UnityEngine;
using UnityEngine.UI;

public class InGameHud : MonoBehaviour
{
    [SerializeField] private Image HealthBar;
    [SerializeField] private Text Timer;

    private bool _gamePaused = true;
    private float _timer = 0.0f;

    private void Start()
    {
        Timer.text = "Timer Paused";
        Timer.color = Color.yellow;
    }

    // Game manager would call this
    public void OnStartGame()
    {
        _gamePaused = false;
        HealthBar.fillAmount = 1;
    }

    private void Update()
    {
        if (_gamePaused)
            return;

        _timer += Time.deltaTime;
        Timer.text = $"{_timer,0:0.000}";
    }

    // Input handler would call this when wanting to show the pause menu
    //     Maybe through the Game Manager
    // Note: DO NOT use OnApplicationPause
    public void OnPauseGame()
    {
        _gamePaused = true;
    }

    // Player or game manager would call this
    public void OnHealthChange(float currentHealth, float maxHealth)
    {
        HealthBar.fillAmount = currentHealth / maxHealth;
    }
}