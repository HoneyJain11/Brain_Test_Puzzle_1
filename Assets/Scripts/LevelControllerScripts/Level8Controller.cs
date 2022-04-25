using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level8Controller : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI levelNo;
    [SerializeField]
    private TextMeshProUGUI levelName;
    [SerializeField]
    private GameObject[] levelSprites;
    [HideInInspector]
    public int count = 0;
    [SerializeField] string setLevelName;
    [SerializeField] string setLevelno;

    void Start()
    {
        SetUI();
    }

    private void SetUI()
    {
        levelNo.text = setLevelno;
        levelName.text = setLevelName;
        for (int i = 0; i < levelSprites.Length; i++)
        {
            levelSprites[i].SetActive(true);
            levelSprites[i].AddComponent<CapsuleCollider2D>().isTrigger = true;
           
        }
        levelName.GetComponent<BoxCollider2D>().enabled = true;

    }


    private void OnDisable()
    {
        if (levelName.gameObject == false)
        {
            levelName.gameObject.SetActive(true);
            levelName.GetComponent<BoxCollider2D>().enabled = false;
            
        }  

    }
    public void CounterUpdate()
    {
        count++;
        if (count == levelSprites.Length)
        {
            EventHandler.Instance.InvokeOnCompleteLevel();

        }
        else
            return;

    }

}
