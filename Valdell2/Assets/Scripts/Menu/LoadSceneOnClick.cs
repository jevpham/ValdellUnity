using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Needed for managing scenes

public class LoadSceneOnClick : MonoBehaviour
{
	public void LoadByIndex(int sceneIndex) // function calls index
    {
        SceneManager.LoadScene(sceneIndex); // Loads Scene number
    }
}
