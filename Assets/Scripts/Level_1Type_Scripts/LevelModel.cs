using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel
{
    public int levelNo { get; set; }
    public string levelTitle { get; set; }
    public Sprite[] levelSpriteElement { get; set; }

    public LevelModel(LevelScriptableObject levelScriptableObject)
    {
        levelNo = levelScriptableObject.levelNo;
        levelTitle = levelScriptableObject.levelTitle;
        levelSpriteElement = levelScriptableObject.levelSpriteElement;
    }

    

}
