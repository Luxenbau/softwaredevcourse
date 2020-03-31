using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public int characterId;
    public int iconID;
    public string playerName;
    public string characterName;
    public int characterHP;
    public int characterInitiative;
    public int initiative;
    public string characterRace;
    public string characterClass;

    public void CharacterData(int _characterId, int _iconID, string _playerName, string _characterName,int _characterHP, int _characterInitiative, string _characterRace, string _characterClass)
    {
        characterId = _characterId;
        iconID = _iconID;
        playerName = _playerName;
        characterName = _characterName;
        characterHP = _characterHP;
        characterInitiative = _characterInitiative;
        characterRace = _characterRace;
        characterClass = _characterClass;
        
    }

}
