using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMaster;
    public AudioMixer audioFX;

    //public TMPro.TMP_Dropdown resolutionDropdown;

    //Resolution[] resolutions;

    /*void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            { 
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    */

    public void SetScreenRes(int ResolutionIndex)
    {
        if (ResolutionIndex == 0)
        {
            Screen.SetResolution(1280, 720, true);
            Debug.Log("resolucion 0");
        }
        else if (ResolutionIndex == 1)
        {
            Screen.SetResolution(1600, 1200, true);
            Debug.Log("resolucion 1");
        }
        else if (ResolutionIndex == 2)
        {
            Screen.SetResolution(1920, 1080, true);
            Debug.Log("resolucion 2");
        }
    }

    public void SetVolumeMaster(float volume)
    {
        audioMaster.SetFloat("volMaster", volume);
    }
    public void SetVolumeFX(float volume)
    {
        audioFX.SetFloat("volFX", volume);
    }

    public void SetQuality(int qualityIndex)
    { 
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    { 
        Screen.fullScreen = isFullScreen;
    }
    
}
