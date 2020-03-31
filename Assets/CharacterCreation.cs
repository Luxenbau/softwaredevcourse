using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public int iconId;
    public bool imageIsSet;
    public Button createBtn;
    public TextMeshProUGUI errorText;


    public void CreateCharacter()
    {
        if (CharacterValidation())
        {
            Character character = new Character();

           int charId =  (int)fireBaseReference.characterCount;

            character.CharacterData(charId, iconId, playerName.text,characterName.text, int.Parse(characterHP.text), int.Parse(characterInitiative.text), characterRace.options[characterRace.value].text, characterClass.options[characterClass.value].text);

            characters.Add(character);

            fireBaseReference.SaveCharacter(character);

            CharacterInfoReset();
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

    public void CharacterInfoReset()
    {
        characterHP.text = "";
        characterName.text = "";
        characterInitiative.text = "";
        playerName.text = "";
        characterRace.value = 0;
        characterClass.value = 0;
    }
    private bool CharacterValidation()
    {
        int t;
        bool isInitiativeInt = int.TryParse(characterInitiative.text, out t);
        bool isHpInt = int.TryParse(characterHP.text, out t);
        if (!imageIsSet)
        {
            return false;
        }
         else if (string.IsNullOrWhiteSpace(playerName.text))
        {
           
            return false;
        }
        else if(string.IsNullOrWhiteSpace(characterName.text))
        {
            
            return false;
        }
        else if (string.IsNullOrWhiteSpace(characterInitiative.text)  )
        {
            return false;
        }
       
        else if (string.IsNullOrWhiteSpace(characterHP.text))
        {
            
            return false;
        }
        else if (isInitiativeInt && isHpInt)
        {
            if (int.Parse(characterInitiative.text) <= 0 || int.Parse(characterInitiative.text) > 1000 || int.Parse(characterHP.text) <=0 || int.Parse(characterHP.text) > 1000)
            {
                errorText.enabled = true;
                return false;
            }
            else
            {
                errorText.enabled = false;
                return true;
            }
        }
        else
        {

            
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        createBtn.interactable = CharacterValidation();
        
    }
}
