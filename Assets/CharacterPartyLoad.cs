using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPartyLoad : MonoBehaviour
{
    public List<Character> partyCharacters = new List<Character>();
    public GameObject characterTemplate;
    public List<GameObject> templates = new List<GameObject>();
    //public List<Character> currentPartyCharacters = new List<Character>();




    public void AddCharactersToParty()
    {
        foreach (var template in templates)
        {
            Destroy(template);

        }
        templates.Clear();

       // currentPartyCharacters.Clear();
        //currentPartyCharacters = partyCharacters;
        

        for (int i = 0; i < partyCharacters.Count; i++)
        {
            Debug.Log("Inside of the for loop");
            GameObject character = Instantiate(characterTemplate, gameObject.transform);
            templates.Add(character);
            character.GetComponent<CharacterDataLoad>().character = partyCharacters[i];
            character.GetComponent<CharacterDataLoad>().currentLocation = "partyPage";

        }

        partyCharacters.Clear();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        //Debug.Log("Current party characters " + currentPartyCharacters.Count);
        Debug.Log("partyCharacters " + partyCharacters.Count);
    }
}
