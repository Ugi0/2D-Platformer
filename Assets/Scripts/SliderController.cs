using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliderController : MonoBehaviour
{
    public TextMeshProUGUI musicSliderText = null;
    public TextMeshProUGUI sfxSliderText = null;
    private float maxSliderAmount = 100.0f;

    public void MusicSliderChange(float value)
    {
        float localValue = value * maxSliderAmount;
        musicSliderText.text = localValue.ToString("0");
    }

    public void sfxSliderChange(float value)
    {
        float localValue = value * maxSliderAmount;
        sfxSliderText.text = localValue.ToString("0");
    }
}
