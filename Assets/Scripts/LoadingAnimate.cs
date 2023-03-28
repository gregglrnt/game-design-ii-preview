using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAnimate : MonoBehaviour
{
    public float alpha = 0.5f;
    [SerializeField] private GameObject loadingMessagePanel;
        // Start is called before the first frame update
    void Start()
    {
        loadingMessagePanel.SetActive(true);    
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAlpha(loadingMessagePanel.GetComponent<Renderer>().material, alpha);   
    }

    void ChangeAlpha(Material material, float alpha)
    {
        Color color = material.color;
        Color newColor = new Color(color.r, color.g, color.b, alpha);
        material.SetColor("_Color", newColor);
    }
}
