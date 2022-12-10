using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillUiComponent : MonoBehaviour
{
    [SerializeField] StatsComponent playerStats;
    [SerializeField] TextMeshProUGUI textAccuracy;
    [SerializeField] TextMeshProUGUI textCurrentHp;
    [SerializeField] TextMeshProUGUI textMaxHp;
    [SerializeField] TextMeshProUGUI textAttack;
    [SerializeField] TextMeshProUGUI textDefense;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        textAccuracy.text = playerStats.Accuracy.ToString();
        textAttack.text = playerStats.Attack.ToString();
        textDefense.text = playerStats.Defence.ToString();
        textCurrentHp.text = playerStats.CurrentHp.ToString();
        textMaxHp.text = playerStats.MaxHp.ToString();
    }
}
