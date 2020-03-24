using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : Monster
{
    public override void MonsterData(int _monsterId)
    {
        monsterId = _monsterId;
        monsterName = "Bandit";
        monsterDamage = "1d6";
        attackModifier = 3;
        monsterHealth = 16;
        imageId = 1;
        monsterInitiative = 2;
    }

    //public override void MonsterData()
    //{
    //    monsterId = 0;
    //    monsterName = "Bandit";
    //    monsterDamage = "1d6";
    //    attackModifier = 3;
    //    monsterHealth = 16;
    //    imageId = 1;
    //    monsterInitiative = 2;
    //}

}
