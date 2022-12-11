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
    public int levelPossible = 0;
    int Level = 1;
    int Exp;

     


    public void TakeDamage(int damage)
    {
        if(!dead &&(CurrentHp -= damage) <= 0)
        {
            dead = true;
        }
    }

    public void OnEnable()
    {
        dead = false;
    }

    public void Heal()
    {
        CurrentHp = MaxHp;
    }
    public void Heal(int amount)
    {
        CurrentHp = CurrentHp + amount > MaxHp ? MaxHp : CurrentHp+amount;
    }

    public void GetExp(int expAmount)
    {
        if ((Exp += expAmount) >= Level * 100)
        {
            Exp -= Level * 100;
            CurrentHp = MaxHp;
            levelPossible++;
            Level++;
        }
    }
    public void LevelUp(string category)
    {
        if(levelPossible >= 1)
        {
            switch (category)
            {
                case "MaxHp":
                    MaxHp++;
                    break;
                 case "Attack":
                    Attack++;
                    break;
                case "Defence":
                    Defence++;
                    break;
                case "Accuracy":
                    Accuracy++;
                    break;
            }
            levelPossible--;
        }
        
    }


}
