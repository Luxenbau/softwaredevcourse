using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Monster
{

    public override void MonsterData(int _monsterId)
    {
        monsterId = _monsterId;
        monsterName = "Wolf";
        monsterDamage = "1d4";
        attackModifier = 3;
        monsterHealth = 10;
        imageId = 0;
        monsterInitiative = 2;
               
    }

}
