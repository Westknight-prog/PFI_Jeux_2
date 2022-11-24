using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsComponent : MonoBehaviour
{
    public int Hp;
    public int Accuracy;
    public int Attack;
    public int Defense;

    public bool TakeDamage(int damage)
    {
        return Hp - damage >= 0;
    }

}
