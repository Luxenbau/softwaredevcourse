using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DiceRoll 
{
    public static int D20()
    {
        int roll = Random.Range(1, 21);
        return roll;
    }
}
