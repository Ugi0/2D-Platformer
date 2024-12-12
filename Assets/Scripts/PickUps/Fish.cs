using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fish", menuName = "PickUps/Fish")]
public class Fish : PickUp
{

    protected override void ApplyPickUp()
    {
        AudioManager.Instance.PlaySFX("Collectable");
        GameWorld.extraTime += 5;
    }

    protected override void RemovePickUp()
    {
        // Ei tapahdu mit��n
    }
}