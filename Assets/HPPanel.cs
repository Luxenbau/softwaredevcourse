using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPPanel : MonoBehaviour
{
    public Monster monster;
    public Character character;
    public TextMeshProUGUI HP;
    public TextMeshProUGUI creatureName;
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
