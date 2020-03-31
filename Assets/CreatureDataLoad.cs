using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CreatureDataLoad : MonoBehaviour, IPointerClickHandler
{
    public int id;
    public TextMeshProUGUI creatureName;
    public TextMeshProUGUI creatureHP;
    public TextMeshProUGUI creatureInitiative;
    public Image creatureImage;
    public Image outline;
    public Monster monster;
    public Character character;
    public bool creatureSelected;
    public Color selectColor;
    public Color standardColor;
    public Image templateBackground;
    public GameObject initiativeRollPanel;
    public string currentLocation;
    public bool creatureTurn;
    public GameObject hpPanel;
    public ChooseImage chooseImage;

    public void CharacterDataLoad()
    {
        creatureName.text = character.characterName;
        creatureHP.text = character.characterHP.ToString();
        creatureInitiative.text = character.initiative.ToString();
        creatureImage.sprite = chooseImage.characterSpriteList[character.iconID];

    }

    public void MonsterDataLoad()
    {
        creatureName.text = monster.monsterName;
        creatureHP.text = monster.monsterHealth.ToString();
        creatureInitiative.text = monster.initiative.ToString();
        creatureImage.sprite = chooseImage.monsterSpriteList[monster.imageId];
    }

    void Update()
    {
        outline.enabled = creatureTurn;

        if (character != null)
        {
            id = character.characterId;
            CharacterDataLoad();
        }

        if (monster != null)
        {
            id = monster.monsterId;
            MonsterDataLoad();
        }

        if (creatureSelected)
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
      
        if (currentLocation == "initiativePage")
        {
            initiativeRollPanel.transform.GetChild(0).gameObject.SetActive(true);

            if (character != null)
            {
                initiativeRollPanel.GetComponent<InitiativePanel>().monster = null;
                initiativeRollPanel.GetComponent<InitiativePanel>().character = character;
            }

            if (monster != null)
            {
                initiativeRollPanel.GetComponent<InitiativePanel>().character = null;
                initiativeRollPanel.GetComponent<InitiativePanel>().monster = monster;
            }
        }
        else if (currentLocation == "battlePage")
        {
            // Future functionality.
            //hpPanel.transform.GetChild(0).gameObject.SetActive(true);

            //if (character != null)
            //{
            //    hpPanel.GetComponent<HPPanel>().character = character;
            //}

            //if (monster != null)
            //{
            //    hpPanel.GetComponent<HPPanel>().monster = monster;
            //}
        }

    }

    void Start()
    {
        initiativeRollPanel = GameObject.FindGameObjectWithTag("InitiativePanel");
        chooseImage = GameObject.FindGameObjectWithTag("ImageScript").GetComponent<ChooseImage>();
        hpPanel = GameObject.FindGameObjectWithTag("HP_Panel");
    }
}
