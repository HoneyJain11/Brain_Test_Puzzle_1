using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2TypeModel 
{
    public int levelNo;
    public string levelTitle;
    public Sprite backgroundSprite;
    public Sprite objectToBeFindSprite;

    public Level2TypeModel(Level2TypeScriptableObjects level2TypeSO)
    {
        levelNo = level2TypeSO.levelNo;
        levelTitle = level2TypeSO.levelTitle;
        backgroundSprite = level2TypeSO.backgroundSprite;
        objectToBeFindSprite = level2TypeSO.objectToBeFindSprite;
    }
}
