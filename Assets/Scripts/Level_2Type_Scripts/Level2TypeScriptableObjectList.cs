using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Level2TypeScriptableObjectList", menuName = "Create2TypeNewLevelList")]
public class Level2TypeScriptableObjectList : ScriptableObject
{
   [SerializeField] Level2TypeScriptableObjects[] level2TypeList;

    public Level2TypeScriptableObjects [] Level2TypeList
    {
        get
        {
            return level2TypeList;
        }

    }
}