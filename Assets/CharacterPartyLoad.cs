using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPartyLoad : MonoBehaviour
{
    public List<Character> partyCharacters = new List<Character>();
    public GameObject characterTemplate;
    public List<GameObject> templates = new List<GameObject>();


    public void AddCharactersToParty()
    {
        foreach (var template in templates)
        {
            Destroy(template);
        }
        templates.Clear();

        for (int i = 0; i < partyCharacters.Count; i++)
        {
            GameObject character = Instantiate(characterTemplate, gameObject.transform);
            templates.Add(character);
            character.GetComponent<CharacterDataLoad>().character = partyCharacters[i];
            character.GetComponent<CharacterDataLoad>().currentLocation = "partyPage";
        }

        partyCharacters.Clear();
    }


}
