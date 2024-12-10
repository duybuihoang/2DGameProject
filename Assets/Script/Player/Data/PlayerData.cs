using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data ")]
public class PlayerData : ScriptableObject
{
    [Header("Basic")]
    public float maxHealth = 100f;
    public float maxMana = 50f;

    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Dash State")]
    public float rollCooldown = 0.5f;
    public float maxHoldTime = 1f;
    public float holdTimeScale = 0.25f;
    public float rollTime = 0.2f;
    public float rollVelocity = 30f;
    public float drag = 10f;
    public float rollEndYMultiplier = 0.2f;
    public float distBetweenAfterImages = 0.5f;
}
