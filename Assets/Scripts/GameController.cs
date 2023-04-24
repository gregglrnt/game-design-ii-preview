using UnityEngine;
using Ink.Runtime;
using UnityEngine.UIElements;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class GameController : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] protected TextAsset inkJSON;
    protected Story story;
    public VisualElement phone;
    public VisualElement choicesBox;

    protected PhoneSoundManager Sounds;

    public GroupBox view;

    private ScrollView scrollView;

    protected const string SPEAKER_TAG = "speaker";
    protected const string WAITING_TAG = "waiting";

    protected string player;

    // Start is called before the first frame update
    protected void Start()
    {
        Debug.Log("gamecontroller start");
        phone = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>("phone");
        initializeInterface();
        scrollView = view.Q<ScrollView>();
        choicesBox = view.Q<GroupBox>();
        Sounds = GameObject.FindObjectOfType<PhoneSoundManager>();
        story = new Story(inkJSON.text);
    }

    public void launch()
    {
        observeVariables();
        Continue();
    }

    protected abstract void observeVariables();

    // Update is called once per frame
    void Update()
    {
    }

    protected IEnumerator continueStory()
    {
        while (story.canContinue)
        {
            string newText = story.Continue();
            handleTags(story.currentTags);
            int wait = handleTags(story.currentTags);
            yield return new WaitForSeconds(wait);
            if (newText != "") pushSMS(newText);
            pushChoices(story.currentChoices);
        }
    }

    protected void Continue()
    {
        StartCoroutine(continueStory());
    }

    protected abstract void initializeInterface();

    protected void pushSMS(String msg)
    {
        if (msg.Trim() == "") return;
        Button newMsg = new Button();
        newMsg.text = msg;
        newMsg.AddToClassList(player + "-msg");
        if (player == "you")
        {
            Sounds.Bloop();
        }
        else
        {
            Sounds.Bubble();
        }
        scrollView.Add(newMsg);
        StartCoroutine(scrollToBottom(newMsg));
    }

    protected IEnumerator scrollToBottom(Button item)
    {
        yield return new WaitForSeconds(0.1f);
        scrollView.ScrollTo(item);
    }

    protected void choiceClicked(int index)
    {
        choicesBox.Clear();
        Sounds.stopType();
        story.ChooseChoiceIndex(index);
        Continue();
    }

    protected void pushChoices(List<Choice> choices)
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

    protected int handleTags(List<string> tags)
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
