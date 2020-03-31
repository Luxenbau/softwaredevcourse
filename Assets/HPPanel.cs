using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// HP panel script, currently not realised, reserved for future functionality
public class HPPanel : MonoBehaviour
{
    public Monster monster;
    public Character character;
    public TextMeshProUGUI HP;
    public TextMeshProUGUI creatureName;
    public TMP_InputField inputField;

    void Update()
    {
        if (character != null)
        {
            HP.text = character.characterHP.ToString();
            creatureName.text = character.characterName;
        }

        if (monster != null)
        {
            HP.text = monster.monsterHealth.ToString();
            creatureName.text = monster.monsterName;
        }
    }

    public void ConfirmHP()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);

        Debug.Log(character);
        Debug.Log(monster);

        if (character != null)
        {
            character.characterHP += int.Parse(inputField.text);
            Debug.Log(character.characterHP);
        }

        if (monster != null)
        {
            monster.monsterHealth += int.Parse(inputField.text);
            Debug.Log(monster.monsterHealth);
        }


    }
}
