using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterDataLoad : MonoBehaviour, IPointerClickHandler
{
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
    //public bool testing;





    public void CharDataLoad()
    {
        //Debug.Log("Starting data load");
        charName.text = character.characterName;
        playerName.text = character.playerName;
        className.text = character.characterClass;
        raceName.text = character.characterRace;
        charHP.text = character.characterHP.ToString();
        charInitiative.text = character.characterInitiative.ToString();

    }



    void Start()
    {
        //if (currentLocation=="selectPage")
        //{
            characterPartyLoad = GameObject.FindGameObjectWithTag("AddPartyScript").GetComponent<CharacterPartyLoad>();
       // }
        // characterPartyLoad = new CharacterPartyLoad();
        
        // character = new Character();
        //character.CharacterData(0, "Mark", "Mark", 10, 4, "Dwarf", "Paladin");
    }

   public void selectCharacters()
    {

    }

    void Update()
    {
        if (character != null)
        {
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
        //if (testing)
        //{
        //    templateBackground.color = selectColor;
        //}
        
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        if (currentLocation == "partyPage")
        {
            // To do : delete the currently selected characters from the party
        }
        else if(currentLocation == "selectPage")
        {


            if (charSelected)
            {
                charSelected = false;

                //*

                //for (int i = 0; i < characterPartyLoad.partyCharacters.Count; i++)
                //{
                //    if (characterPartyLoad.partyCharacters[i].characterId == character.characterId)
                //    {
                //        characterPartyLoad.partyCharacters.RemoveAt(i);
                //    }
                //}
                   
                //characterPartyLoad.partyCharacters.Remove(character);
            }
            else
            {
                charSelected = true;

                //characterPartyLoad.partyCharacters.Add(character);

            }
        }
     Debug.Log(characterPartyLoad.partyCharacters.Count + " characters selected");
    }
}
