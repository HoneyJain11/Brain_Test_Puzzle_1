using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelScriptableObjectList", menuName = "CreateNewLevelList")]
public class LevelScriptableObjectList : ScriptableObject
{
    public LevelScriptableObject[] levels;

}