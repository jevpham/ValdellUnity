using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoOptions : MonoBehaviour
{
    // Create resolution class of Dropdown menu
    public Dropdown resolutionDropdown;

    // Array of resolutions
    Resolution[] resolutions; 
    
	// Use this for initialization
	void Start ()
    {
        // Adds screen resolutions to array
        resolutions = Screen.resolutions;

        // Clears irrelevant resolutions
        resolutionDropdown.ClearOptions();

        // New list to store string of options
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        // Array that displays resolution values
        for (int i = 0; i < resolutions.Length; i++)
        {
            // Displays string of resolutions in list
            string option = resolutions[i].width + " x " + resolutions[i].height;

            // Adds strings of resolutions to list
            options.Add(option);

            // Sets default resolution for system
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Adds options list to resolution dropdown
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
	}
	
	public void setResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
