using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class CharacterData {
    //public string characterName;
    public int goldCount = 0;
    public int levelId = 0;

    public void setGoldCount(int _goldCount)
    {
        goldCount = _goldCount;
    }

    public void setLevelId(int _levelId)
    {
        levelId = _levelId;
    }

    public int getGoldCount()
    {
        return goldCount;
    }

    public int getLevelId()
    {
        return levelId;
    }
}
