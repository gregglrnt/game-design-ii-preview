using UnityEngine;
using UnityEngine.UIElements;

public class PhoneController : MonoBehaviour {

    public ColocController coloc;
    public PoliceController police;

    private VisualElement phone;

    private Button colocButton;
    private Button policeButton;


    void Start() {
        coloc = GameObject.FindObjectOfType<ColocController>();
        police = GameObject.FindObjectOfType<PoliceController>();
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        phone = root.Q<VisualElement>("phone");
        VisualElement toggle = root.Q<VisualElement>("Toggle");
        colocButton = toggle.Q<Button>("colocButton");
        policeButton = toggle.Q<Button>("policeButton");
        colocButton.clicked += () => openColoc();
        policeButton.clicked += () => openPolice();
        openColoc();
        coloc.launch();
    }

    public void openColoc() {
        Debug.Log("openColoc");
        police.view.style.opacity = 0;
        coloc.view.style.opacity = 1;

    }

    public void openPolice() {
        Debug.Log("openPolice");
        coloc.view.style.opacity = 0;
        police.view.style.opacity = 1;
    }

}