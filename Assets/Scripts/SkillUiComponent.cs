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
    [SerializeField] TextMeshProUGUI AttUp;
    [SerializeField] TextMeshProUGUI AccUp;
    [SerializeField] TextMeshProUGUI DefUp;
    [SerializeField] TextMeshProUGUI MaxHpUp;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        Time.timeScale = 0;
        updateStatsValue();
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void updateStatsValue()
    {
        textAccuracy.text = playerStats.Accuracy.ToString();
        textAttack.text = playerStats.Attack.ToString();
        textDefense.text = playerStats.Defence.ToString();
        textCurrentHp.text = playerStats.CurrentHp.ToString();
        textMaxHp.text = playerStats.MaxHp.ToString();

        if (playerStats.levelPossible >= 1)
        {
            AttUp.gameObject.SetActive(true);
            AccUp.gameObject.SetActive(true);
            DefUp.gameObject.SetActive(true);
            MaxHpUp.gameObject.SetActive(true);
        }
        else
        {
            AttUp.gameObject.SetActive(false);
            AccUp.gameObject.SetActive(false);
            DefUp.gameObject.SetActive(false);
            MaxHpUp.gameObject.SetActive(false);
        }

    }
    public void LevelUpAcc() { playerStats.LevelUp("Accuracy"); updateStatsValue(); }
    public void LevelUpAtt() { playerStats.LevelUp("Attack"); updateStatsValue(); }
    public void LevelUpDef() { playerStats.LevelUp("Defence"); updateStatsValue(); }
    public void LevelUpMaxHp() { playerStats.LevelUp("MaxHp"); updateStatsValue(); }
}
