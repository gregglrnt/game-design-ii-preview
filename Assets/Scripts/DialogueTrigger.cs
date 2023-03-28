using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueTrigger : MonoBehaviour {
        
        [Header("Ink JSON")]
        [SerializeField] private TextAsset inkJSON;

        private void Awake() {
        }

        private void Update() {
            // button.onClick.AddListener(() => {
            //     Debug.Log("Button clicked");
            //     DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            // });
            if(Input.GetMouseButtonDown(0)) {
                Debug.Log("Button clicked");
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }

            // reference the object this script is attached to
            /*GameObject thisObject = this.gameObject; 
            print(thisObject);*/
                //DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
}
