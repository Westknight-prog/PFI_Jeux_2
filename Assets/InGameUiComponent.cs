using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUiComponent : MonoBehaviour
{
    [SerializeField] StatsComponent playerStats;
    [SerializeField] Image xpBar;
    [SerializeField] Image hpBar;
    [SerializeField] TextMeshProUGUI lvlText;
    float oldXp = 100;
    float oldHp;
    int oldLvl = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerStats.CurrentHp != oldHp)
        {
            oldHp = playerStats.CurrentHp;
            hpBar.fillAmount = (float)playerStats.CurrentHp / (float)playerStats.MaxHp;
        }
        if (playerStats.Exp != oldXp)
        {
            oldXp = playerStats.Exp;
            xpBar.fillAmount = (float)playerStats.Exp / ((float)playerStats.Level*100);
        }
        if(playerStats.Level != oldLvl)
        {
            oldLvl = playerStats.Level;
            lvlText.text = "LVL : " + playerStats.Level;
        }

    }
}
