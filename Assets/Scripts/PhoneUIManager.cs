using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PhoneUIManager : MonoBehaviour {
    
    private Label timeLabel;
    private PhoneController gameManager;

    private GameController gameController;

    // private ProgressBar battery;

    private float timePassed = 5f;

    private void Start() {
        // refacto this with global interface
        //gameManager = GameObject.FindObjectOfType<GameManager>();
        gameController = GameObject.FindObjectOfType<ColocController>();
        timeLabel = gameController.phone.Q<Label>("Time");
        //battery = gameController.phone.Q<ProgressBar>("ProgressBar");

    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= 5f)
        {
            UpdateTime();
            //UpdateBattery();
            timePassed = 0f;
        }
    }

    void UpdateTime() {
        //timeLabel.text = DateTime.Now.ToString("HH:mm");
    }

    /*void UpdateBattery()
    {
        float lifeBattery = battery.highValue;

        while (lifeBattery > 0f)
        {
            lifeBattery -= Time.deltaTime;
        }
    }*/


}