using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;  
    public TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions;

    public void Start()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option); 

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

        Screen.fullScreen = true;
    }

    public void SetMusique(float volume)
    {
        audioMixer.SetFloat("Musique", volume);
    }
    
    public void SetSound(float volume)
    {
        audioMixer.SetFloat("Sound", volume);
    }

    public void SetFulleScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
