using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InitiativePanel : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI initiative;
    public TextMeshProUGUI creatureName;
    public Character character;
    public Monster monster;
    public Button confirmInitiativeButton;


    public void InitiativeRoll()
    {
        inputField.text = DiceRoll.D20().ToString();
    }

    public void ConfirmInitiative()
    {
        if (inputField.text != "")
        {
            if (character != null)
            {
                character.initiative = int.Parse(inputField.text) + character.characterInitiative;
            }

            if (monster != null)
            {
                monster.initiative = int.Parse(inputField.text) + monster.monsterInitiative;

            }
        }
        inputField.text = "";
    }

    public bool isInputCorrect()
    {
        int t;
        bool isNumberInt = int.TryParse(inputField.text, out t);
        if (string.IsNullOrWhiteSpace(inputField.text))
        {
            return false;
        }
        else if (isNumberInt)
        {
            if (int.Parse(inputField.text) <= 0 || int.Parse(inputField.text) > 20)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }
    void Update()
    {
        if (character != null)
        {
            initiative.text = "+" + character.characterInitiative;
            creatureName.text = character.characterName;
        }

        if (monster != null)
        {
            initiative.text = "+" + monster.monsterInitiative;
            creatureName.text = monster.monsterName;
        }

        confirmInitiativeButton.interactable = isInputCorrect();
    }
}
