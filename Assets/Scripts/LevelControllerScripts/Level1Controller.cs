using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Level1Controller : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelNoText;
    [SerializeField] TextMeshProUGUI levelTitleText;
    [SerializeField] GameObject levelSprite;
    [SerializeField] Sprite[] levelSpriteElement;
    [SerializeField] string levelName;
    [SerializeField] string levelno;
    int count = 0;
    [SerializeField] UIController uIController;

    private void Start()
    {
        SetUI();


    }
    public void SetUI()
    {
        levelTitleText.text = levelName;
        levelNoText.text = levelNoText.text +" " + levelno.ToString();
        levelTitleText.GetComponent<BoxCollider2D>().enabled = false;
        levelSprite.GetComponent<SpriteRenderer>().sprite = levelSpriteElement[count];
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
                //Debug.Log("Hit with GameObject " + hit.collider.gameObject.name);
                OnTouch();
            }
        }
    }

    public void OnTouch()
    {
        //Debug.Log(""+ levelModel.levelSpriteElement.Length);
        if (count < levelSpriteElement.Length - 1)
        {
            count++;
            levelSprite.GetComponent<SpriteRenderer>().sprite = levelSpriteElement[count];
        }
        else
        {
            count = 0;
            levelSprite.SetActive(false);
            levelTitleText.text = "";
            levelNoText.text = "";
            EventHandler.Instance.InvokeOnCompleteLevel();
        }

    }

}
