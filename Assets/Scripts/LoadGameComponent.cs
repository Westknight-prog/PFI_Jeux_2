using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LoadGameComponent : MonoBehaviour
{
    [SerializeField] StatsComponent playerStats;
    void Awake()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.GetString("Type") == "Continue")
        {
            string[] listStats = PlayerPrefs.GetString("playerStats").Split(',');
            string[] listPosition = PlayerPrefs.GetString("playerPosition").Split(',');
            Vector3 positionSaved = new Vector3(float.Parse(listPosition[0]), float.Parse(listPosition[1]), float.Parse(listPosition[2]));

            playerStats.Level = int.Parse(listStats[0]);
            playerStats.Exp = int.Parse(listStats[1]);
            playerStats.levelPossible = int.Parse(listStats[2]);
            playerStats.CurrentHp = int.Parse(listStats[3]);
            playerStats.MaxHp = int.Parse(listStats[4]);
            playerStats.Accuracy = int.Parse(listStats[5]);
            playerStats.Attack = int.Parse(listStats[6]);
            playerStats.Defence = int.Parse(listStats[7]);

            playerStats.gameObject.GetComponent<NavMeshAgent>().Warp(positionSaved);

        }
       
    }
    public void SaveGame()
    {
        PlayerPrefs.SetString("playerStats", $"{playerStats.Level}," +
                                             $"{playerStats.Exp}," +
                                             $"{playerStats.levelPossible}," +
                                             $"{playerStats.CurrentHp}," +
                                             $"{playerStats.MaxHp}," +
                                             $"{playerStats.Accuracy}," +
                                             $"{playerStats.Attack}," +
                                             $"{playerStats.Defence}");

        PlayerPrefs.SetString("playerPosition", $"{playerStats.gameObject.transform.position.x}," +
                                               $"{playerStats.gameObject.transform.position.y}," +
                                               $"{playerStats.gameObject.transform.position.z}");
    }

    void Update()
    {
        
    }
}
