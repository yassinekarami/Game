using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UIElements;

public class UiController : MonoBehaviour
{
    public UIDocument uiDocument;
    private Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void updateUI()
    {
        Debug.Log("update UI");
        var root = uiDocument.rootVisualElement;

        // Get the slider by name
        healthSlider = root.Q<Slider>("HealthSilder");

        // Set slider value programmatically
        healthSlider.value = healthSlider.value - 10;
    }
}
