using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiativeCreaturesTemplateLoad : MonoBehaviour
{
    public GameObject creatureTemplate;
    public MonsterTemplateLoad monsterTemplateLoad;
    public CharacterPartyLoad characterPartyLoad;
    public List<GameObject> creaturesTemplates = new List<GameObject>();
    public GameObject confirmInitiativeBtn;
    public BattleCreaturesTemplateLoad battleCreaturesTemplateLoad;


    public void ConfirmAllInitiatives()
    {
        battleCreaturesTemplateLoad.creaturesTemplates.AddRange(creaturesTemplates);
        battleCreaturesTemplateLoad.LoadBattlePanel();
    }

    public void UnloadCreatures()
    {
        for (int i = 0; i < creaturesTemplates.Count; i++)
        {
            Destroy(creaturesTemplates[i]);
        }

        creaturesTemplates.Clear();
    }

    public void LoadCreatures()
    {
        UnloadCreatures();

        foreach (var characterTemplate in characterPartyLoad.templates)
        {
            GameObject creatureTemp =Instantiate(creatureTemplate, gameObject.transform);

            creatureTemp.GetComponent<CreatureDataLoad>().character = characterTemplate.GetComponent<CharacterDataLoad>().character;

            creatureTemp.GetComponent<CreatureDataLoad>().currentLocation = "initiativePage";

            creaturesTemplates.Add(creatureTemp);
        }

        foreach (var monsters in monsterTemplateLoad.monsterTemplates)
        {
            GameObject creatureTemp = Instantiate(creatureTemplate, gameObject.transform);

            creatureTemp.GetComponent<CreatureDataLoad>().monster = monsters.GetComponent<MonsterDataLoad>().monster;

            creatureTemp.GetComponent<CreatureDataLoad>().currentLocation = "initiativePage";

            creaturesTemplates.Add(creatureTemp);
        }

        foreach (var template in creaturesTemplates)
        {
            if (template.GetComponent<CreatureDataLoad>().character != null)
            {
                template.GetComponent<CreatureDataLoad>().character.initiative = 0;
            }

            if (template.GetComponent<CreatureDataLoad>().monster != null)
            {
                template.GetComponent<CreatureDataLoad>().monster.initiative = 0;
            }
        }
    }

    public void RollInitiativeForAll()
    {
        foreach (var creature in creaturesTemplates)
        {
            Monster monster = creature.GetComponent<CreatureDataLoad>().monster;
            Character character = creature.GetComponent<CreatureDataLoad>().character;

            if (monster != null)
            {
                if (monster.initiative == 0)
                {
                    monster.initiative = DiceRoll.D20() + monster.monsterInitiative;
                }
            }

            if (character != null)
            {
                if (character.initiative == 0)
                {
                    character.initiative = DiceRoll.D20() + character.characterInitiative;
                }
            }
        }
    }


    public void CheckInitiativeOfAllCreatures()
    {
        int amountCreaturesWithInitiative = 0;

        foreach (var creature in creaturesTemplates)
        {
            Monster monster = creature.GetComponent<CreatureDataLoad>().monster;
            Character character = creature.GetComponent<CreatureDataLoad>().character;

            if (monster != null)
            {
                if (monster.initiative != 0)
                {
                    amountCreaturesWithInitiative++;
                }
            }

            if (character != null)
            {
                if (character.initiative != 0)
                {
                    amountCreaturesWithInitiative++;
                }
            }
        }

        if (creaturesTemplates.Count > 0)
        {
            if (amountCreaturesWithInitiative == creaturesTemplates.Count)
            {
                confirmInitiativeBtn.SetActive(true);
            }
            else
            {
                confirmInitiativeBtn.SetActive(false);
            }
        }
    }

    private void Update()
    {
        CheckInitiativeOfAllCreatures();
    }
}
