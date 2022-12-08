using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameComponent : MonoBehaviour
{
    [SerializeField] StatsComponent playerStats;
    void Awake()
    {
        if (PlayerPrefs.GetString("Type") == "Continue")
        {
            Debug.Log("Continue");
            playerStats.Attack = PlayerPrefs.GetInt("Attack");
            playerStats.Accuracy = PlayerPrefs.GetInt("Accuracy");
            playerStats.Defense = PlayerPrefs.GetInt("Defense");
            playerStats.MaxHp = PlayerPrefs.GetInt("MaxHp");
            playerStats.CurrentHp = PlayerPrefs.GetInt("CurrentHp");
        }
        else
        {
            Debug.Log("New Game");
        }
    }
    public void SaveGame()
    {
        PlayerPrefs.SetInt("Attack", playerStats.Attack);
        PlayerPrefs.SetInt("Accuracy", playerStats.Accuracy);
        PlayerPrefs.SetInt("Defense", playerStats.Defense);
        PlayerPrefs.SetInt("MaxHp", playerStats.MaxHp);
        PlayerPrefs.SetInt("CurrentHp", playerStats.CurrentHp);
    }

    void Update()
    {
        
    }
}
