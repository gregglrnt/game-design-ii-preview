using UnityEngine;
using System;
using UnityEngine.UIElements;

public class ColocController : GameController
{

    public enum ROOMS {
        SALON, 
        CUISINE, 
        CHAMBRE,
        CAVE,
        BUREAU,
    };

    public ROOMS currentRoom = ROOMS.SALON;

    // Start is called before the first frame update
    protected override void observeVariables() {
        story.ObserveVariable("room", (variableName, newValue) => {
            currentRoom = (ROOMS)Enum.Parse(typeof(ROOMS), newValue.ToString());
        });
        story.ObserveVariable("timerStart", (variableName, newValue) => {
            if(newValue.Equals(true)) {
                GameObject.FindObjectOfType<TimerManager>().timerStart();
            }
        });
    }

    public void shutDownLights() {
        story.ChoosePathString("shutDownLights");
    }

    protected override void initializeInterface()
    {
        view = phone.Q<GroupBox>("colocScreen");
    }
}
