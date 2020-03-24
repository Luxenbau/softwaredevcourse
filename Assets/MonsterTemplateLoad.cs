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

    public void LoadMonsters() {
        //wolfData = new Wolf();
        //banditData = new Bandit();
        //wolfData.MonsterData(0);
        //banditData.MonsterData(0);
        //LoadDataToTemplate();
        
    }

    public void LoadSelectedMonsterPanel(string _selectedMonster)
    {
        selectedMonster = _selectedMonster;

    }

    public void AddMonster()
    {
        Debug.Log("Selected monster is" + selectedMonster);
        Debug.Log(selectedMonsterNumber.text);

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
        
    }
}
