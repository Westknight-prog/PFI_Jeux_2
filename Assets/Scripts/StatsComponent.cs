using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsComponent : MonoBehaviour
{
    public int MaxHp;
    public int CurrentHp;
    public int Accuracy;
    public int Attack;
    public int Defence;
    public bool dead = false;


    public void TakeDamage(int damage)
    {
        Debug.Log(gameObject.name + " takes " + damage + " damage");
        if(!dead &&(CurrentHp -= damage) <= 0)
        {
            dead = true;
        }
    }

    public void OnEnable()
    {
        CurrentHp = MaxHp;
        dead = false;
    }


}
