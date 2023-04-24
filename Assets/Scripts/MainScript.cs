using UnityEngine;
using Ink.Runtime;
using UnityEngine.UIElements;
using System.Collections;
using System;
using System.Collections.Generic;

public class MainScript : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private Story story;
    public VisualElement phone;
    private VisualElement choicesBox;

    private PhoneSoundManager Sounds;

    private ScrollView view;

    private bool hasKnife = false;

    private const string SPEAKER_TAG = "speaker";
    private const string WAITING_TAG = "waiting";

    private int loops = 0;

    public enum ROOMS {
        SALON, 
        CUISINE, 
        CHAMBRE,
        CAVE,
        SDB,
        BUREAU,
    };

    public ROOMS currentRoom = ROOMS.SALON;

    private string player;

    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkJSON.text);
        story.ObserveVariable("room", (variableName, newValue) => {
            currentRoom = (ROOMS)Enum.Parse(typeof(ROOMS), newValue.ToString());
        });
        story.ObserveVariable("timerStart", (variableName, newValue) => {
            if(newValue.Equals(true)) {
                GameObject.FindObjectOfType<TimerManager>().timerStart();
            }
        });
        Continue();
    }

    // Update is called once per frame
    void Update() {
    }

    private IEnumerator continueStory()
    {
        while (story.canContinue)
        {
            string newText = story.Continue();
            handleTags(story.currentTags);
            int wait = handleTags(story.currentTags);
            yield return new WaitForSeconds(wait);
            if(newText != "") pushSMS(newText);
            pushChoices(story.currentChoices);
        }
    }

    private void Continue()
    {
        loops++;
        StartCoroutine(continueStory());
    }

    private void OnEnable()
    {
        phone = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>("phone");
        view = phone.Q<ScrollView>("msgBox");
        choicesBox = phone.Q<VisualElement>("choicesBox");
        Sounds = GameObject.FindObjectOfType<PhoneSoundManager>();
    }

    private void pushSMS(String msg)
    {
        if(msg.Trim() == "") return;
        Button newMsg = new Button();
        newMsg.text = msg;
        newMsg.AddToClassList(player+"-msg");
        if(player == "you") {
            Sounds.Bloop();
        } else {
            Sounds.Bubble();
        }
        view.Add(newMsg);
        StartCoroutine(scrollToBottom(newMsg));
    }

    private IEnumerator scrollToBottom(Button item) {
        yield return new WaitForSeconds(0.1f);
        view.ScrollTo(item);
    }

    private void choiceClicked(int index)
    {
        choicesBox.Clear();
        Sounds.stopType();
        story.ChooseChoiceIndex(index);
        Continue();
    }

    private void pushChoices(List<Choice> choices)
    {
        Sounds.type();
        foreach (Choice choice in choices)
        {
            Button outgoing = new Button();
            outgoing.text = choice.text;
            outgoing.AddToClassList("me-msg");
            outgoing.clicked += () =>
            {
                choiceClicked(choice.index);
            };
            choicesBox.Add(outgoing);
        }
    }

    public void shutDownLights() {
        story.ChoosePathString("shutDownLights");
    }
    
    private int handleTags(List<string> tags)
    {
        int wait = 2;
        foreach (string tag in tags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                continue;
            }
            switch (splitTag[0])
            {
                case SPEAKER_TAG:
                    player = splitTag[1].Trim();
                    break;
                case WAITING_TAG:
                    wait = int.Parse(splitTag[1]);
                    break;
            }
        }

        return wait;
    }

}
