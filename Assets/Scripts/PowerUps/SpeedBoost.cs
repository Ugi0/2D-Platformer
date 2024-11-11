using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedBoost", menuName = "PowerUps/SpeedBoost")]
public class SpeedBoost : PowerUp
{
    public float speedMultiplier = 2f;

    protected override void ApplyPowerUp()
    {
        player.moveSpeed *= speedMultiplier;
    }

    protected override void RemovePowerUp()
    {
        player.moveSpeed /= speedMultiplier;
    }
}