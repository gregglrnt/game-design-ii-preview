using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{

    [Header("Dialogue Ui")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choiceTexts;

    private Story currentStory;

    private bool dialogueIsPlaying;

    private static DialogueManager instance;

    public static DialogueManager GetInstance() {
        return instance;
    }

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    private void Start() {
        Debug.Log("start");
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        choiceTexts = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices) {
            choiceTexts[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON) {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();        
    }

    private void ExitDialogueMode() {
        Debug.Log("Exit dialogue mode");
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void Update() {
        if (!dialogueIsPlaying) {
            return;
        }
        //ContinueStory();
    }

    private void ContinueStory() {
        Debug.Log("Continue story");
        if(currentStory.canContinue) {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        } else {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices() {
        List<Choice> currentChoices = currentStory.currentChoices;
        Debug.Log("Let's display the choices " + currentChoices.Count);

        if(currentChoices.Count > choices.Length) {
            Debug.LogError("Not enough choices UI elements");
            return;
        }

        int index = 0;
        foreach(Choice choice in currentChoices) {
            choices[index].gameObject.SetActive(true);
            choiceTexts[index].text = choice.text;
            index++;
        } 

        for(int i = index; i < choices.Length; i++) {
            choices[i].gameObject.SetActive(false);
        }
    }
    

    public void MakeChoice(int choiceIndex) {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

}