using System;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterTemplateLoad : MonoBehaviour
{
    public GameObject wolfTemplate;
    public GameObject banditTemplate;
    public Wolf wolfData;
    public Bandit banditData;
    string selectedMonster;
    public TMP_InputField selectedMonsterNumber;
    public int monsterCount;
    public List<Monster> monsters = new List<Monster>();
    public GameObject monsterTemplate;
    public List<GameObject> monsterTemplates = new List<GameObject>();
    public List<GameObject> monstersTemplateToDelete = new List<GameObject>();
    public GameObject showDeletePanel;
    public Button addMonsterBtn;

   

    public void LoadSelectedMonsterPanel(string _selectedMonster)
    {
        selectedMonster = _selectedMonster;
    }

    public void AddMonster()
    {
        monsterCount = int.Parse(selectedMonsterNumber.text);        
        if (monsterCount>0)
        {
          int  monsterCountTemp = monsters.Count;
            for (int i = 0; i < monsterCount; i++)
            {
            GameObject monsterTemp = Instantiate(monsterTemplate, gameObject.transform);
                if (selectedMonster == "Wolf")
                {
                    Wolf wolf = new Wolf();
                    wolf.MonsterData( i + monsterCountTemp);
                    monsterTemp.GetComponent<MonsterDataLoad>().monster = wolf ;
                } else if (selectedMonster == "Bandit")
                {

                    Bandit bandit = new Bandit();
                    bandit.MonsterData(i + monsterCountTemp);
                    monsterTemp.GetComponent<MonsterDataLoad>().monster = bandit;
                }
                monsterTemplates.Add(monsterTemp);

                monsters.Add(monsterTemp.GetComponent<MonsterDataLoad>().monster);

            }    
        }
        selectedMonsterNumber.text = "";
    }

    public bool MonsterNumberValidation()
    {
        int t;
        bool isNumberInt = int.TryParse(selectedMonsterNumber.text, out t);
        
        if (string.IsNullOrWhiteSpace(selectedMonsterNumber.text))
        {
            return false;
        }
        else if ( isNumberInt)
        {
            if (int.Parse(selectedMonsterNumber.text) <=0 || int.Parse(selectedMonsterNumber.text) >100 )
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

    public void MonsterDelete()
    {
        foreach (var monsterToDelete in monstersTemplateToDelete)
        {
            monsterTemplates.Remove(monsterToDelete);
            monsters.Remove(monsterToDelete.GetComponent<MonsterDataLoad>().monster);
            Destroy(monsterToDelete.gameObject);
        }

        monstersTemplateToDelete.Clear();
        // reset the monster ids
        ResetIdAfterDelete();
    }

    // resetnut idshniki posle udalenija monstrov
    public void ResetIdAfterDelete()
    {
        for (int i = 0; i < monsterTemplates.Count; i++)
        {
            monsterTemplates[i].GetComponent<MonsterDataLoad>().monster.monsterId = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (monstersTemplateToDelete.Count>0)
        {
            showDeletePanel.SetActive(true);

        } else
        {
            showDeletePanel.SetActive(false);
        }

        addMonsterBtn.interactable = MonsterNumberValidation();

    }
}
