using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHPComponent : MonoBehaviour
{
    Image hpBar;
    [SerializeField] StatsComponent characterStats;
    int oldHp;
    void Awake()
    {
       hpBar = gameObject.GetComponent<Image>();
       oldHp = characterStats.CurrentHp;
       hpBar.fillAmount = characterStats.MaxHp / characterStats.CurrentHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(oldHp != characterStats.CurrentHp)
        {
            oldHp = characterStats.CurrentHp;
            hpBar.fillAmount =  (float)characterStats.CurrentHp/(float)characterStats.MaxHp;
        }
    }
}
