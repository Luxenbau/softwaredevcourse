using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// default abstract monster class from which monsters will be generated
public abstract class Monster 
{
    public int monsterId;
    public string monsterName;
    public string monsterDamage;
    public int attackModifier;
    public int monsterHealth;
    public int monsterInitiative;
    public int initiative;
    public int imageId;

    public abstract void MonsterData(int monsterId);



}
