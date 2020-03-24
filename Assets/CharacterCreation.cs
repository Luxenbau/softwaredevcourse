using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterCreation : MonoBehaviour
{
    //Character character;
    public List<Character> characters = new List<Character>();
    public TMP_InputField playerName;
    public TMP_InputField characterName;
    public TMP_InputField characterHP;
    public TMP_InputField characterInitiative;
    public TMP_Dropdown characterRace;
    public TMP_Dropdown characterClass;
    public FireBaseConnect fireBaseReference;


    public void CreateCharacter()
    {
        if (CharacterValidation())
        {

            Character character = new Character();

           int charId =  (int)fireBaseReference.characterCount;

            character.CharacterData(charId, 0, playerName.text,characterName.text, int.Parse(characterHP.text), int.Parse(characterInitiative.text), characterRace.options[characterRace.value].text, characterClass.options[characterClass.value].text);


            characters.Add(character);

            fireBaseReference.SaveCharacter(character);
            
         //   ShowCharactersList();
        }
        else
        {
            Debug.Log("Сheck that all fields are filled");
        }
    }
    
    private void ShowCharactersList()
    {
        foreach (var character in characters)
        {
            Debug.Log(string.Format("Character: {0} \nIcon ID: {1} \nPlayer: {2} \nCharacter: {3}  \nHP: {4}  \nInitiative: {5} \nRace: {6} \nClass: {7}",
                characters.IndexOf(character), 0, character.playerName, character.characterName, character.characterHP, character.characterInitiative, character.characterRace, character.characterClass));
        }
    }

    private bool CharacterValidation()
    {
        if (string.IsNullOrWhiteSpace(playerName.text))
        {
            return false;
        }
        else if(string.IsNullOrWhiteSpace(characterName.text))
        {
            return false;
        }
        else if (string.IsNullOrWhiteSpace(characterHP.text))
        {
            return false;
        }
        else if (string.IsNullOrWhiteSpace(characterInitiative.text))
        {
            //TODO Int validation
            return false;
        }
        else
        {
            return true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
