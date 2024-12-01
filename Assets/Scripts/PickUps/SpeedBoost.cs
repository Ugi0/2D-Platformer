using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedBoost", menuName = "PickUps/SpeedBoost")]
public class SpeedBoost : PickUp
{
    public float speedMultiplier = 2f;

    protected override void ApplyPickUp()
    {
        player.moveSpeed *= speedMultiplier;
    }

    protected override void RemovePickUp()
    {
        player.moveSpeed /= speedMultiplier;
    }
}