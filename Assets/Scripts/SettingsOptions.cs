using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class SettingsOptions : MonoBehaviour
{
    public AudioSource SFXaudio;
    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
         for(int i=0;i<resolutions.Length;i++)
            {
                string option = resolutions[i].width +" x " + resolutions[i].height;
                options.Add(option);
            }
        resolutionDropdown.AddOptions(options);

    }

    public void SetVolume (float volume)
        {
            SFXaudio.volume = volume;
        }
    public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }
    public void FullScreen(bool fs)
        {
            Screen.fullScreen = fs;
        }
}
