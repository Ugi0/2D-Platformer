using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fish", menuName = "PickUps/Fish")]
public class Fish : PickUp
{
    public GameObject textUIPrefab;
    private GameObject textUI;

    protected override void ApplyPickUp(Player player)
    {
        AudioManager.Instance.PlaySFX("Collectable");
        GameWorld.extraTime += 5;
        if (textUIPrefab != null)
        {
            textUI = Instantiate(textUIPrefab, player.transform.position, Quaternion.identity);
        }
    }

    protected override void RemovePickUp()
    {
        if (textUI != null)
        {
            Destroy(textUI);
        }
    }
}