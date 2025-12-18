using UnityEngine;
using UnityEngine.UI; // Needed if you want to display on UI Text

public class CounterTimer : MonoBehaviour
{
    public Text timerText; // Optional: Assign a UI Text element in the Inspector
    public bool autoStart = true; // Start counting automatically
    public bool showInConsole = true; // Log time in Console

    private float elapsedTime = 0f; // Time in seconds
    private bool isRunning = false;

    void Start()
    {
        if (autoStart)
            StartTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime; // Add time since last frame

            // Convert to minutes:seconds format
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            string timeFormatted = string.Format("{0:00}:{1:00}", minutes, seconds);

            // Display in UI if assigned
            if (timerText != null)
                timerText.text = timeFormatted;

            // Optionally log to console
            if (showInConsole)
                Debug.Log("Timer: " + timeFormatted);
        }
    }

    // Public methods to control the timer
    public void StartTimer()
    {
        isRunning = true;
    }

    public void PauseTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        if (timerText != null)
            timerText.text = "00:00";
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}
