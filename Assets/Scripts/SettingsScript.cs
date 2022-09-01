using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsScript : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1f);
            Load();
        }
    }
    
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }

    //List<int> widths = new List<int>() { 568, 960, 1280, 1920 };
    //List<int> heights = new List<int>() { 329, 540, 800, 1080 };

    List<int> widths = new List<int>() { 1920, 1280, 960, 568 };
    List<int> heights = new List<int>() { 1080, 800, 540, 329 };

    public void SetScreenSize(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }

    public void SetFullscreen(bool _fullscreen)
    {
        Screen.fullScreen = _fullscreen;
    }

}
