using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public LevelLoader levelLoader = null;

    public TextMeshProUGUI musicSliderText = null;
    public TextMeshProUGUI sfxSliderText = null;

    public Button musicButton;
    public Button sfxButton;

    public Slider musicSlider;
    public Slider sfxSlider;

    public Sprite soundOffImage;
    public Sprite soundOnImage;

    private bool musicMuted;
    private bool sfxMuted;

    private float previousMusicValue;
    private float previousSfxValue;

    void Start()
    {
        previousMusicValue = 0.5f;
        previousSfxValue = 0.5f;
    }

    public void PlayGame() {
        levelLoader.Load();
    }

    public void QuitGame()
    {
        Debug.Log("Application quit!");
        Application.Quit();
    }

    public void MusicSliderChange(float value)
    {
        float localValue = value * 100.0f;
        musicSliderText.text = localValue.ToString("0");
        AudioListener.volume = localValue;
        if(value == 0)
        {
            musicMuted = true;
            musicButton.image.sprite = soundOffImage;
        } else
        {
            musicMuted = false;
            musicButton.image.sprite = soundOnImage;
        }
    }

    public void sfxSliderChange(float value)
    {
        float localValue = value * 100.0f;
        sfxSliderText.text = localValue.ToString("0");
        if (value == 0)
        {
            sfxMuted = true;
            sfxButton.image.sprite = soundOffImage;
        }
        else
        {
            sfxMuted = false;
            sfxButton.image.sprite = soundOnImage;
        }
    }

    public void musicMute()
    {
        if(musicMuted)
        {
            musicSlider.value = Mathf.Clamp(previousMusicValue, 0.01f, 1.0f);
            musicMuted = false;
        } else
        {
            previousMusicValue = musicSlider.value;
            musicSlider.value = 0;
        }
    }

    public void sfxMute()
    {
        if (sfxMuted)
        {
            sfxSlider.value = Mathf.Clamp(previousSfxValue, 0.01f, 1.0f);
            sfxMuted = false;
        }
        else
        {
            previousSfxValue = sfxSlider.value;
            sfxSlider.value = 0;
        }
    }
}
