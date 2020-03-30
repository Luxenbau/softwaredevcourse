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

    // Start is called before the first frame update
    void Start()
    {
        
    }

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

    // Update is called once per frame
    void Update()
    {
        if (character != null)
        {
            initiative.text = "+" + character.characterInitiative;
            creatureName.text = character.characterName;
            Debug.Log("Test penis char1");
        }

        if (monster != null)
        {
            
            initiative.text = "+" + monster.monsterInitiative;
            creatureName.text = monster.monsterName;
            Debug.Log("Test penis char2 ");
        }
    }
}
