using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeQuit : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Esc Key pressed
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // If running in Unity Editor quit
#else
        Application.Quit (); // If running application quit
#endif
        }

    }
}
