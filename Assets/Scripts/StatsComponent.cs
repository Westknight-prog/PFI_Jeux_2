using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsComponent : MonoBehaviour
{
    public int MaxHp;
    public int CurrentHp;
    public int Accuracy;
    public int Attack;
    public int Defense;

    public void TakeDamage(int damage)
    {
        CurrentHp -= damage;
    }

}
