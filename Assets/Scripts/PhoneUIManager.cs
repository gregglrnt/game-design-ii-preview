using System;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PhoneUIManager : MonoBehaviour {
    
    private MainScript mainScript; 
    private Label timeLabel;
    private Color color911;
    private Color colorColoc;
    private Button button911;
    private Button buttonColoc;

    private float timePassed = 5f;

    private void changeColor911()
    {
        color911 = Color.HSVToRGB(51, 102, 255);
        button911.color = color911;
    }

    private void Start() {
        mainScript = GameObject.FindObjectOfType<MainScript>();
        timeLabel = mainScript.phone.Q<Label>("Time");

        if (button911)
        {
            changeColor911();
        }

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