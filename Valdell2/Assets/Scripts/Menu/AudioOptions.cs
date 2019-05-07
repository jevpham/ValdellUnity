using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioOptions : MonoBehaviour
{
    // Calls AudioMixer class to change volume levels
    public AudioMixer masterMixer;
    public AudioMixer effectsMixer;
    public AudioMixer musicMixer;

    // Function that sets volume using float
	public void setMasterVolume(float newMasterVolume)
    {
        masterMixer.SetFloat("Volume", newMasterVolume);
    }

    public void setEffectsVolume(float newEffectsVolume)
    {
        effectsMixer.SetFloat("Volume", newEffectsVolume);
    }

    public void setMusicVolume(float newMusicVolume)
    {
        musicMixer.SetFloat("Volume", newMusicVolume);
    }
}
