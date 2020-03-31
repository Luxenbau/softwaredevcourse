using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterTemplateLoad : MonoBehaviour
{
    public GameObject characterTemplate;
    public bool connectComplete;
   [SerializeField] FireBaseConnect firebase;
    public List<Character> characters = new List<Character>();
    public List<GameObject> templates = new List<GameObject>();
    [SerializeField] CharacterPartyLoad characterPartyLoad;

    void Start()
    {
        GetData();
    }

    public void GetData()
    {
        for (int i = 0; i < templates.Count; i++)
        {
            Destroy(templates[i].gameObject);
        }
        templates.Clear();
        characters.Clear();
        firebase.GetCharactersFromDatabase();
    }

    public void AddSelectedCharacters()
    {
        // adding selected chars to party
        foreach (var template in templates)
        {
            if (template.GetComponent<CharacterDataLoad>().charSelected)
            {
                characterPartyLoad.partyCharacters.Add(template.GetComponent<CharacterDataLoad>().character);
            }
        }

        characterPartyLoad.AddCharactersToParty();
    }

    public void SelectCharactersThatAreAlreadyInParty()
    {
        foreach (var character in templates)
        {
            character.GetComponent<CharacterDataLoad>().charSelected = false;
        }

        if (characterPartyLoad.templates.Count > 0)
        {
            foreach (var character in templates)
            {
                foreach (var currentCharacter in characterPartyLoad.templates)
                {
                    if (character.GetComponent<CharacterDataLoad>().character.characterId == currentCharacter.GetComponent<CharacterDataLoad>().character.characterId)
                    {
                        character.GetComponent<CharacterDataLoad>().charSelected = true;
                    }
                }
            }
        }
    }

    public void LoadCharactersTemplates()
    {
        characters = firebase.CharacterList();

        for (int i = 0; i < characters.Count; i++)
        {   
            GameObject character = Instantiate(characterTemplate, gameObject.transform);
            templates.Add(character);
            character.GetComponent<CharacterDataLoad>().character = characters[i];
            // Save location of the view, where it is located ( party or character add )
            character.GetComponent<CharacterDataLoad>().currentLocation = "selectPage";

        }
    }
   
    void Update()
    {
        if (connectComplete)
        {
            LoadCharactersTemplates();
            SelectCharactersThatAreAlreadyInParty();
            connectComplete = false;
        }
    }
}
