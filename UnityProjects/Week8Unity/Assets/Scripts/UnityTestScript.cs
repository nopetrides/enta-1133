using UnityEngine;

public class UnityTestScript : MonoBehaviour
{
    private int _timesEnabled = 0;
    private float _timer = 0f;
    /// <summary>
    /// Awake is called when the script instance is being loaded
    /// </summary>
    private void Awake()
    {
        Debug.Log("Awake");
    }
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        Debug.Log("Start");
    }
    private void OnEnable()
    {
        _timesEnabled++;
        Debug.Log($"I've been enabled {_timesEnabled} times"); // interpolation
        _timer = 0f;
    }
    private void OnDisable()
    {
        Debug.Log($"I was updating for {_timer, 0:000.000} seconds");
    }
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        _timer += Time.deltaTime; // Time between frames (in fractions of a second)
    }
}
