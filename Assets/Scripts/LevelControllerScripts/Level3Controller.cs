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
    
    [SerializeField] string setLevelName;
    [SerializeField] string setLevelno;
    [SerializeField] Camera setCameraReference;
    private void Start()
    {
        SetUI();
    }

    private void SetUI()
    {
        setCameraReference.transform.position = new Vector3(0f, 0f, -10f);
        levelName.text = setLevelName;
        levelNo.text = setLevelno;
        for (int i =0; i<levelSprites.Length;i++)
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
                EventHandler.Instance.InvokeOnCompleteLevel();
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

  private /*async*/ void WrongAnswer(Vector3 position)
    {
        /* GameObject cross = ObjectPooler.Instance.GetPooledObject();
         cross.SetActive(true);
         cross.transform.position = position;
         Handheld.Vibrate();
         await new WaitForSeconds(0.5f);
         cross.SetActive(false);*/
        EventHandler.Instance.InvokeOnIncorrectInput(position);

    }

}
