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
    private VisualElement view;
    private VisualElement choicesBox;

    private bool hasKnife = false;

    private const string SPEAKER_TAG = "speaker";
    private const string WAITING_TAG = "waiting";

    private string player;

    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkJSON.text);
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
            handleVariables(story.variablesState);
            int wait = handleTags(story.currentTags);
            yield return new WaitForSeconds(wait);
            pushSMS(newText);
            pushChoices(story.currentChoices);
        }
    }

    private void Continue()
    {
        StartCoroutine(continueStory());
    }

    private void OnEnable()
    {
        phone = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>("phone");
        view = phone.Q<VisualElement>("msgBox");
        choicesBox = phone.Q<VisualElement>("choicesBox");
    }

    private void pushSMS(String msg)
    {
        Button newMsg = new Button();
        newMsg.text = msg;
        newMsg.AddToClassList(player+"-msg");
        if(player == "incoming") {
            GameObject.FindObjectOfType<PhoneSoundManager>().Bloop();
        } else {
            GameObject.FindObjectOfType<PhoneSoundManager>().Bubble();
        }
        view.Add(newMsg);
    }

    private void choiceClicked(int index)
    {
        choicesBox.Clear();
        story.ChooseChoiceIndex(index);
        Continue();
    }

    private void pushChoices(List<Choice> choices)
    {
        foreach (Choice choice in choices)
        {
            Button outgoing = new Button();
            outgoing.text = choice.text;
            outgoing.AddToClassList("outcoming-msg");
            outgoing.clicked += () =>
            {
                choiceClicked(choice.index);
            };
            choicesBox.Add(outgoing);
        }
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


    private void handleVariables(VariablesState variables)
    {
        if (variables.GetVariableWithName("hasKnife")) {
            hasKnife = true;
        }
    }

}
