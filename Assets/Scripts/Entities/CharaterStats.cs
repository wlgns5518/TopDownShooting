using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StatsChangeType
{
    Add,
    Muptiple,
    Override
}
public class CharaterStats
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;

    //공격데이터

}
