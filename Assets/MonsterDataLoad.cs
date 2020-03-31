using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MonsterDataLoad : MonoBehaviour, IPointerClickHandler
{
    public int id;
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
    public MonsterTemplateLoad monsterTemplateLoad;
    public ChooseImage chooseImage;

    public void DataLoad()
    {
        
        monsterName.text = monster.monsterName;
        monsterDamage.text = monster.monsterDamage;
        monsterHP.text = monster.monsterHealth.ToString();
        monsterInitiative.text = monster.monsterInitiative.ToString();
        attackModifier.text = monster.attackModifier.ToString();
        monsterImage.sprite = chooseImage.monsterSpriteList[monster.imageId];
    }

    void Update()
    {
        if (monster != null)
        {
            id = monster.monsterId;
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

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (monsterSelected)
        {
            monsterSelected = false;
            monsterTemplateLoad.monstersTemplateToDelete.Remove(gameObject);
            
        } else if (!monsterSelected)
        {
            monsterSelected = true;
            monsterTemplateLoad.monstersTemplateToDelete.Add(gameObject);
        }
    }

    void Start()
    {
        monsterTemplateLoad = GameObject.FindGameObjectWithTag("MonsterTemplate").GetComponent<MonsterTemplateLoad>();
        chooseImage = GameObject.FindGameObjectWithTag("ImageScript").GetComponent<ChooseImage>();

    }
}
