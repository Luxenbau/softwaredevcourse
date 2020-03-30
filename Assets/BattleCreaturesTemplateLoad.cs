using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCreaturesTemplateLoad : MonoBehaviour
{
    public GameObject creatureTemplate;
    public GameObject helpPanelParty;
    public GameObject helpPanelEnemy;
    public GameObject startEncounterBtn;
    public Image backgroundPanel;
    public GameObject battleButtons;
    public MonsterTemplateLoad monsterTemplateLoad;
    public CharacterPartyLoad characterPartyLoad;
    public List<GameObject> creaturesTemplates = new List<GameObject>();
    public List<Monster> monsters = new List<Monster>();
    public List<Character> characters = new List<Character>();
    public List<GameObject> loadedCreaturesTemplates = new List<GameObject>();
    public Button partyButtonBlock;
    public Button enemyButtonBlock;


    static int SortByInitiative(GameObject creature1, GameObject creature2)
    {
        int initiative1 = int.Parse(creature1.GetComponent<CreatureDataLoad>().creatureInitiative.text);
        int initiative2 = int.Parse(creature2.GetComponent<CreatureDataLoad>().creatureInitiative.text);

        return -initiative1.CompareTo(initiative2);
    }

    //public void AddCreatureObject()
    //{
    //    Debug.Log("TEEEST1");

    //    foreach (var template in creaturesTemplates)
    //    {
    //        Debug.Log("TEEEST2");
    //        foreach (var monster in monsterTemplateLoad.monsters)
    //        {
    //            Debug.Log("TEEEST3");
    //            if (template.GetComponent<CreatureDataLoad>().id == monster.monsterId)
    //            {
    //                Debug.Log("TEEEST4");
    //                template.GetComponent<CreatureDataLoad>().monster = monster;
    //            }
    //        }

    //        foreach (var character in characterPartyLoad.partyCharacters)
    //        {
    //            Debug.Log("TEEEST5");
    //            if (template.GetComponent<CreatureDataLoad>().id == character.characterId)
    //            {
    //                Debug.Log("TEEEST6");
    //                template.GetComponent<CreatureDataLoad>().character = character;
    //            }
    //        }
    //    }
    //}

    public void NextTurn()
    {
        creaturesTemplates.Add(creaturesTemplates[0]);
        creaturesTemplates.RemoveAt(0);

        foreach (var template in creaturesTemplates)
        {
            template.GetComponent<CreatureDataLoad>().creatureTurn = false;
        }

        creaturesTemplates[0].GetComponent<CreatureDataLoad>().creatureTurn = true;

        LoadCreaturesInBattle();
    }



    public void LoadCreaturesInBattle()
    {
        for (int i = 0; i < loadedCreaturesTemplates.Count; i++)
        {
            Destroy(loadedCreaturesTemplates[i]);
        }

        loadedCreaturesTemplates.Clear();

        foreach (var template in creaturesTemplates)
        {
            GameObject temp = Instantiate(template, gameObject.transform);
            loadedCreaturesTemplates.Add(temp);
        }

        //AddCreatureObject();

        //LoadBattlePanel();
    }

    public void LoadBattlePanel()
    {
        backgroundPanel.enabled = true;
        battleButtons.SetActive(true);
        partyButtonBlock.interactable = false;
        enemyButtonBlock.interactable = false;

        foreach (var template in creaturesTemplates)
        {
            template.GetComponent<CreatureDataLoad>().currentLocation = "battlePage";
            template.GetComponent<CreatureDataLoad>().creatureTurn = false;
        }

        creaturesTemplates.Sort(SortByInitiative);

        creaturesTemplates[0].GetComponent<CreatureDataLoad>().creatureTurn = true;

        LoadCreaturesInBattle();
    }
    public void EndBattle()
    {
        partyButtonBlock.interactable = true;
        enemyButtonBlock.interactable = true;

        foreach (var template in creaturesTemplates)
        {
            template.GetComponent<CreatureDataLoad>().currentLocation = "";
            template.GetComponent<CreatureDataLoad>().creatureTurn = false;
        }

        for (int i = 0; i < loadedCreaturesTemplates.Count; i++)
        {
            Destroy(loadedCreaturesTemplates[i]);
        }
        loadedCreaturesTemplates.Clear();
        creaturesTemplates.Clear();




    }

    public void CheckAmountOfCreatures()
    {
        if (characterPartyLoad.templates.Count != 0 && monsterTemplateLoad.monsterTemplates.Count != 0)
        {
            startEncounterBtn.SetActive(true);
        }
        else
        {
            startEncounterBtn.SetActive(false);
        }

        if (characterPartyLoad.templates.Count == 0)
        {
            helpPanelParty.SetActive(true);
        }
        else
        {
            helpPanelParty.SetActive(false);
        }

        if (monsterTemplateLoad.monsterTemplates.Count == 0)
        {
            helpPanelEnemy.SetActive(true);
        }
        else
        {
            helpPanelEnemy.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckAmountOfCreatures();
    }
}
