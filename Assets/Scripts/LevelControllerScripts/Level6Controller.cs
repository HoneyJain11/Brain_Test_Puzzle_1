using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Level6Controller : MonoBehaviour
{
    [SerializeField]
    GameObject gameObjectSet;
    [SerializeField]
    TextMeshProUGUI levelNo;
    [SerializeField]
    TextMeshProUGUI levelTitle;
    [SerializeField] string setLevelName;
    [SerializeField] string setLevelno;
    [SerializeField]
    private GameObject crossSign;
    private void Start()
    {
        SetUI();
    }

    private void SetUI()
    {
        levelNo.text = setLevelno;
        levelTitle.text = setLevelName;
        levelTitle.GetComponent<BoxCollider2D>().enabled = true;
        gameObjectSet.SetActive(true);
    }

    private void Update()
    {
        TapLogic();
    }

    private void TapLogic()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);
            if (hit && hit.collider != null)
            {
                //gameObjects
                Debug.Log("Tree Found");
                gameObjectSet.SetActive(false);
                //Level Complete
                levelTitle.GetComponent<BoxCollider2D>().enabled = false;
                EventHandler.Instance.InvokeOnCompleteLevel();
            }
            else
            {
                WrongAnswer(pos);
            }

           }
     }

    private  void WrongAnswer(Vector3 position)
    {
        EventHandler.Instance.InvokeOnIncorrectInput(position);

    }
}
