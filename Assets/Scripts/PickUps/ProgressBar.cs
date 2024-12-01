using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [Header("UI References")]
    public Image timerBar;

    [Header("Progress Settings")]
    private float maxValue = 100f;
    private float currentValue;

    private void Start()
    {
        ResetBar();
    }

    public void SetMaxValue(float max)
    {
        maxValue = max;
        currentValue = maxValue;
        UpdateBar();
    }

    public void SetCurrentValue(float value)
    {
        currentValue = Mathf.Clamp(value, 0, maxValue);
        UpdateBar();
    }

    public void ResetBar()
    {
        currentValue = maxValue;
        UpdateBar();
    }

    private void UpdateBar()
    {
        if (timerBar != null)
        {
            timerBar.fillAmount = currentValue / maxValue;
        }
    }
}