using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

// Allows use of keyboard or controller for menu selection
public class SelectOnInput : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject selectedObject;

    private bool buttonSelected; // Checks for only one button to be selected

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Vertical axis
		if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
        {
            // Selects any given object first on the panel
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }

        // Horizontal axis
        if (Input.GetAxisRaw("Horizontal") != 0 && buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
	}

    // Deactivates object if nothing is selected
    private void OnDisable()
    {
        buttonSelected = false;
    }
}
