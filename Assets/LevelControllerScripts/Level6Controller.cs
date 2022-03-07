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
    [SerializeField]
    private GameObject crossSign;
    private void Start()
    {
        SetUI();
    }

    private void SetUI()
    {
        levelNo.text = "Level : 6";
        levelTitle.text = "Tap On Tree";
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
            }
            else
            {
                WrongAnswer(pos);
            }

           }
     }

    private async void WrongAnswer(Vector3 position)
    {
        Instantiate(crossSign, position, Quaternion.identity);
        crossSign.SetActive(true);
        position.z = 0f;
        crossSign.transform.position = position;
        Handheld.Vibrate();
        await new WaitForSeconds(0.5f);
        crossSign.SetActive(false);

    }
}
