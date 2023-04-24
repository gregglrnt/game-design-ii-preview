using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private int seconds = 0;
    private bool timerStarted = false;

    private const int SHUTTING_DOWN_TIME = 120;


    void Update()
    {
        if (timerStarted && Time.time > seconds)
        {
            seconds += 1;
            if(seconds == SHUTTING_DOWN_TIME)
            {
                Debug.Log("Lights are shutting down");
                GameObject.FindObjectOfType<MainScript>().shutDownLights();
            }
        }
    }

    public void timerStart() {
        timerStarted = true;
    }
}
