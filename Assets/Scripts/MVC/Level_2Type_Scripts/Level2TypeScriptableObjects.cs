using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level2TypeScriptableObject", menuName = "Create2TypeNewLevel")]
public class Level2TypeScriptableObjects : ScriptableObject
{
    public int levelNo;
    public string levelTitle;
    public Sprite backgroundSprite;
    public Sprite objectToBeFindSprite;
}
