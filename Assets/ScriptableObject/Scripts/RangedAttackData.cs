using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DefaultAttackData", menuName = "TopDownController/Attacks/Ranged", order = 1)]
public class RangedAttackData : AttackSO
{
    [Header("RagedAttackData")]
    public string bulletNameTag;
    public float duration;
    public float spread;
    public int numberOfProjectilesPerShot;
    public float multipleProjectilesAngel;
    public Color projectileColor;
}
