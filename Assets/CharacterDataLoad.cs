using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterDataLoad : MonoBehaviour, IPointerClickHandler
{
    public int id;
    public TextMeshProUGUI charName;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI className;
    public TextMeshProUGUI raceName;
    public TextMeshProUGUI charHP;
    public TextMeshProUGUI charInitiative;
    public Image charImage;
    public Character character;
    public Image templateBackground;
    public bool charSelected;
    public Color selectColor;
    public Color standardColor; 
    public CharacterPartyLoad characterPartyLoad;
    public string currentLocation;
    public ChooseImage chooseImage;


    public void CharDataLoad()
    {
        charName.text = character.characterName;
        playerName.text = character.playerName;
        className.text = character.characterClass;
        raceName.text = character.characterRace;
        charHP.text = character.characterHP.ToString();
        charInitiative.text = character.characterInitiative.ToString();
        charImage.sprite = chooseImage.characterSpriteList[character.iconID];

    }

    void Start()
    {
            characterPartyLoad = GameObject.FindGameObjectWithTag("AddPartyScript").GetComponent<CharacterPartyLoad>();
            chooseImage = GameObject.FindGameObjectWithTag("ImageScript").GetComponent<ChooseImage>();
    }

    void Update()
    {
        if (character != null)
        {
            id = character.characterId;
            CharDataLoad();
        }
        if (charSelected)
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
        if (currentLocation == "partyPage")
        {
        }
        else if(currentLocation == "selectPage")
        {
            if (charSelected)
            {
                charSelected = false;
            }
            else
            {
                charSelected = true;
            }
        }
    }
}
