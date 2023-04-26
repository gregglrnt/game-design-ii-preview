using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PhoneUIManager : MonoBehaviour {
    
    private MainScript mainScript; 
    private Label timeLabel;


    private float timePassed = 5f;


    private void Start() {
        mainScript = GameObject.FindObjectOfType<MainScript>();
        timeLabel = mainScript.phone.Q<Label>("Time");

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
        timeLabel.text = DateTime.Now.ToString("HH:mm");
    }


}