using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MonsterDataLoad : MonoBehaviour
{
    public TextMeshProUGUI monsterName;
    public TextMeshProUGUI monsterDamage;
    public TextMeshProUGUI monsterHP;
    public TextMeshProUGUI monsterInitiative;
    public TextMeshProUGUI attackModifier;
    public Image monsterImage;
    public Monster monster;
    public bool monsterSelected;
    public Color selectColor;
    public Color standardColor;
    public Image templateBackground;


    public void DataLoad()
    {
        //Debug.Log("Starting data load");
        monsterName.text = monster.monsterName;
        monsterDamage.text = monster.monsterDamage;
        monsterHP.text = monster.monsterHealth.ToString();
        monsterInitiative.text = monster.monsterInitiative.ToString();
        attackModifier.text = monster.attackModifier.ToString();


    }

    void Update()
    {
        if (monster != null)
        {
            DataLoad();
        }
        if (monsterSelected)
        {
            templateBackground.color = selectColor;

        }
        else
        {
            templateBackground.color = standardColor;
        }
    }
}
