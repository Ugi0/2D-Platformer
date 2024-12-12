using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : ScriptableObject
{
    public string pickUpName;
    public float duration;
    public GameObject hudElementPrefab;

    protected Player player;
    protected ProgressBar timerBar;

    public virtual void Activate(Player player, GameObject hudContainer)
    {
        this.player = player;

        if (hudElementPrefab != null)
        {
            GameObject hudElementInstance = Instantiate(hudElementPrefab, hudContainer.transform);
            timerBar = hudElementInstance.GetComponent<ProgressBar>();

            if (timerBar != null)
            {
                timerBar.SetMaxValue(duration);
                timerBar.SetCurrentValue(duration);
            }
        }

        PickUpManager.Instance.StartCoroutine(ApplyEffect());
    }

    protected abstract void ApplyPickUp();
    protected abstract void RemovePickUp();

    private IEnumerator ApplyEffect()
    {
        AudioManager.Instance.PlaySFX("Collectable");
        ApplyPickUp();
        float remainingTime = duration;

        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            // Update the timer bar if it exists
            if (timerBar != null)
                timerBar.SetCurrentValue(remainingTime);

            yield return null;
        }

        RemovePickUp();

        // Destroy the HUD element after the power-up ends
        if (timerBar != null)
            Destroy(timerBar.gameObject);
    }
}