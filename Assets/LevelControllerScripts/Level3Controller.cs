using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Level3Controller : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI levelNo;
    [SerializeField]
    private TextMeshProUGUI levelName;
    [SerializeField]
    private GameObject[] levelSprites;
    [SerializeField]
    private GameObject crossSign;
    private void Start()
    {
        SetUI();
    }

    private void SetUI()
    {
        levelNo.text = "Level : 3";
        levelName.text = "Find The Different One ?";
        for(int i =0; i<levelSprites.Length;i++)
        {
            levelSprites[i].SetActive(true);
        }
        
    }

    private void Update()
    {
        DetectGameObject();
    }

    public void DetectGameObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);
            if (hit && hit.collider != null)
            {
                Debug.Log("Hit with GameObject " + hit.collider.gameObject.name);
               // winpanel;
               // winsound;
            }
            else
            {
                Debug.Log("Open Close image");
                //cross image;
                //error sound;
                pos.z = 0f;
                WrongAnswer(pos);
            }
        }
    }

  private async void WrongAnswer(Vector3 position)
    {
        Instantiate(crossSign, position, Quaternion.identity);
        crossSign.SetActive(true);
        crossSign.transform.position = position;
        Handheld.Vibrate();
        await new WaitForSeconds(0.5f);
        crossSign.SetActive(false);

    }

}
