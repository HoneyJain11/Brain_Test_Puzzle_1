using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelScriptableObject", menuName = "CreateNewLevel")]
public class LevelScriptableObject : ScriptableObject
{
  
    public int levelNo;
    public string levelTitle;
    public Sprite[] levelSpriteElement;

}


