using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public int monsterId;
    public string monsterName;
    public string monsterDamage;
    public int attackModifier;
    public int monsterHealth;
    public int monsterInitiative;
    public int imageId;

    public abstract void MonsterData(int monsterId);
   // public abstract void MonsterData();


}
