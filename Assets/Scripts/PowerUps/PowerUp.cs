using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : ScriptableObject
{
    public string powerUpName;
    public float duration;
    public GameObject hudElementPrefab;

    protected Player player;
    protected ProgressBar timerBar;

    public virtual void Activate(Player player, GameObject hudContainer)
    {
        this.player = player;

        // Instantiate the HUD element and get the TimerBar component
        GameObject hudElementInstance = Instantiate(hudElementPrefab, hudContainer.transform);
        timerBar = hudElementInstance.GetComponent<ProgressBar>();

        if (timerBar != null)
        {
            timerBar.SetMaxValue(duration);
            timerBar.SetCurrentValue(duration);
        }

        PowerUpManager.Instance.StartCoroutine(ApplyEffect());
    }

    protected abstract void ApplyPowerUp();
    protected abstract void RemovePowerUp();

    private IEnumerator ApplyEffect()
    {
        ApplyPowerUp();
        float remainingTime = duration;

        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            // Update the timer bar if it exists
            if (timerBar != null)
                timerBar.SetCurrentValue(remainingTime);

            yield return null;
        }

        RemovePowerUp();

        // Destroy the HUD element after the power-up ends
        if (timerBar != null)
            Destroy(timerBar.gameObject);
    }
}