using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private int seconds = 0;
    private bool timerStarted = false;

    private const int SHUTTING_DOWN_TIME = 75;

    private const int END_TIME = 180;

    private PhoneController gameManager;

    void Start() {
        gameManager = GameObject.FindObjectOfType<PhoneController>();
    }

    void Update()
    {
        if (timerStarted && Time.time > seconds)
        {
            seconds += 1;
            if (seconds == SHUTTING_DOWN_TIME)
            {
                Debug.Log("Lights are shutting down");
                gameManager.coloc.shutDownLights();
                gameManager.police.launch();
            }
            if (seconds == END_TIME)
            {
                Debug.Log("Game Over");
                gameManager.police.policeIsComing();
            }
        }
    }

    public void timerStart() {
        timerStarted = true;
    }
}
