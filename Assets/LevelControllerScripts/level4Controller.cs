using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class level4Controller : MonoBehaviour
{
    [SerializeField]
    GameObject gameObjectSet;
    [SerializeField]
    TextMeshProUGUI levelNo;
    [SerializeField]
    TextMeshProUGUI levelTitle;
    [SerializeField]
    List<Sequence> sequenceElements;
    List<Sequence> emptySequenceElements;

    int count = 0;

    private void Start()
    {
        SetUI();

        emptySequenceElements = new List<Sequence>();
    }

    private void SetUI()
    {
        levelNo.text = "Level : 4";
        levelTitle.text = "Set In A Sequeance";
        gameObjectSet.SetActive(true);
    }

    private void Update()
    {
        SetInSequence();
    }

    private void SetInSequence()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);
            if (hit && hit.collider != null)
            {
                //gameObjects
                gameObjectSet.SetActive(false);

                if (count < sequenceElements.Count)
                {
                    emptySequenceElements.Add(hit.collider.gameObject.GetComponent<Sequence>());
                    count++;
                    hit.collider.gameObject.GetComponentInChildren<Text>().text = count.ToString();
                    if (count == sequenceElements.Count)
                        print("Your ans is " + CheckAnswer());
                    //Debug.Log("Level Complete Animation");
                }
                
               
                
            }
            else
            {
                Debug.Log("Open Close image");
                //cross image;
                //error sound;
             
            }
        }

    }

    private bool CheckAnswer()
    {
        bool correct = false;
        for (int i= 0; i<sequenceElements.Count;i++)
        {
            if (emptySequenceElements[i].id == sequenceElements[i].id)
            {
                correct = true;
            }
            else
            {
                correct = false;
                gameObjectSet.SetActive(true);
                emptySequenceElements.Clear();
                count = 0;
                break;
            }   
        }
        return correct;
    }
}

