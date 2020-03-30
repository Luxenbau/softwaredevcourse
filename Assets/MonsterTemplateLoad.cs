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
                    Debug.Log("monsterTemp1 is " + monsterTemp.GetComponent<MonsterDataLoad>().monster.monsterName);
                } else if (selectedMonster == "Bandit")
                {

                    Bandit bandit = new Bandit();
                    bandit.MonsterData(i + monsterCountTemp);
                    monsterTemp.GetComponent<MonsterDataLoad>().monster = bandit;
                    Debug.Log("monsterTemp2 is " + monsterTemp.GetComponent<MonsterDataLoad>().monster.monsterName);
                }
                Debug.Log("monsterTemp3 is " + monsterTemp.GetComponent<MonsterDataLoad>().monster.monsterName);
                monsterTemplates.Add(monsterTemp);

                monsters.Add(monsterTemp.GetComponent<MonsterDataLoad>().monster);
                Debug.Log("monsterTemp4 is " + monsterTemp.GetComponent<MonsterDataLoad>().monster.monsterName);


            }

       
        }
        selectedMonsterNumber.text = "";
    }

    public void MonsterDelete()
    {

       

        foreach (var monsterToDelete in monstersTemplateToDelete)
        {
            monsterTemplates.Remove(monsterToDelete);
            monsters.Remove(monsterToDelete.GetComponent<MonsterDataLoad>().monster);
            Destroy(monsterToDelete.gameObject);
        }

        //foreach (var template in monstersTemplateToDelete)
        //{
        //    Destroy(template.gameObject);
        //}

        monstersTemplateToDelete.Clear();


       

        Debug.Log("monstersTemplateToDelete.Count = " + monstersTemplateToDelete.Count);
        Debug.Log("monsterTemplates.Count = " + monsterTemplates.Count);
        Debug.Log("monsters.Count = " + monsters.Count);

        foreach (var item in monsterTemplates)
        {
            Debug.Log("1monsterId = "+ item.GetComponent<MonsterDataLoad>().monster.monsterId);
        }

        // reset the damn ids
        ResetIdAfterDelete();

        foreach (var item in monsterTemplates)
        {
            Debug.Log("2monsterId = " + item.GetComponent<MonsterDataLoad>().monster.monsterId);
        }

        //foreach (var item in monsterTemplates)
        //{
        //    Debug.Log("2monsterId = " + item.GetComponent<MonsterDataLoad>().monster.monsterId);
        //}

    }

    // resetnut idshniki posle udalenija monstrov
    public void ResetIdAfterDelete()
    {
        for (int i = 0; i < monsterTemplates.Count; i++)
        {
            monsterTemplates[i].GetComponent<MonsterDataLoad>().monster.monsterId = i;
        }
    }



    public void LoadDataToTemplate()
    {
        //wolfTemplate.GetComponent<MonsterDataLoad>().monster = wolfData;
        //banditTemplate.GetComponent<MonsterDataLoad>().monster = banditData;

    }

    // Start is called before the first frame update
    void Start()
    {

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
    }
}
