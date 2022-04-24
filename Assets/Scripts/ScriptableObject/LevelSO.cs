using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSO", menuName = "ScriptableObject/NewLevelSO")]
public class LevelSO : ScriptableObject
{
    public int levelNo;
    public GameObject levelObject;
}
[CreateAssetMenu(fileName = "LevelSOList", menuName = "ScriptableObjectList/NewLevelSOList")]
public class LevelSOList : ScriptableObject
{
    public LevelSO[] levels;
}
