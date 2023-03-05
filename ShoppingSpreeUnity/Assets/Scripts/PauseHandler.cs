using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseHandler : MonoBehaviour
{
    public GameObject playUI;
    public GameObject menuUI;
    public bool paused;
    public AudioMixer mixer;
    public static float volumeLevel = 1.0f;
    private Slider sliderVolumeCtrl;

    void Awake ()
    {
        SetLevel(volumeLevel);
    }

    void Start()
    {
        Resume();
    }
    
    public void SetLevel (float sliderValue)
    {
        mixer.SetFloat("Volume", Mathf.Log10 (sliderValue) * 20);
        volumeLevel = sliderValue;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        playUI.SetActive(true);
        menuUI.SetActive(false);
        paused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        playUI.SetActive(false);
        menuUI.SetActive(true);
        paused = true;
    }

    public void QuitGame(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
