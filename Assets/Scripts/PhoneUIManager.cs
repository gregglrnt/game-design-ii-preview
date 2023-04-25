using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PhoneUIManager : MonoBehaviour {
    
    private Label timeLabel;
    private PhoneController gameManager;

    private GameController gameController;

    private float timePassed = 5f;

    private void Start() {
        // refacto this with global interface
        // gameManager = GameObject.FindObjectOfType<GameManager>();
        // gameController = GameObject.FindObjectOfType<ColocController>();
        // timeLabel = gameController.phone.Q<Label>("Time");

    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= 5f)
        {
            UpdateTime();
            timePassed = 0f;
        }
    }

    void UpdateTime() {
        //timeLabel.text = DateTime.Now.ToString("HH:mm");
    }


}