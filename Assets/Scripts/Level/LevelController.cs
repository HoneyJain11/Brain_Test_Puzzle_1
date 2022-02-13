using UnityEngine;
using System.Collections;
using System;

public class LevelController
{
    public LevelView levelView;
    public LevelModel levelModel;
    int counter = 0;
    //int levelCount = 0;

    //public int LevelCount{get=>levelCount;}

    public LevelController()
    {
    }

    public LevelController(LevelModel levelModel,LevelView levelView)
    {
        this.levelModel = levelModel;
        this.levelView = levelView;
        
    }
    public void SetUI()
    {
        levelView.levelTitleText.text = levelModel.levelTitle;
        levelView.levelNoText.text = levelView.levelNoText.text + " " + levelModel.levelNo.ToString();
        levelView.levelSprite.GetComponent<SpriteRenderer>().sprite = levelModel.levelSpriteElement[counter];
    }
    public void SetUI(string levelNo, string levelTitle, Sprite[] images)
    {
            levelView.levelTitleText.text = levelTitle;
            levelView.levelNoText.text = "";
            levelView.levelNoText.text = levelNo;
            levelView.levelSprite.GetComponent<SpriteRenderer>().sprite = images[counter];
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
        if(counter < levelModel.levelSpriteElement.Length-1)
        {
            counter++;
            levelView.levelSprite.GetComponent<SpriteRenderer>().sprite = levelModel.levelSpriteElement[counter];
        }
        else
        {
            //Complete win particle effect
            // Level Complete Dialogbox.
            counter = 0;
            Debug.Log("Level Complete");           
            NextLevel();
        }
        

    }

    public void NextLevel()
    {
        //levelView.GameObjectDestory();
        levelView.levelCount++;
        //levelView.NextLevel(levelView.levelCount);
        if (levelView.levelCount < levelView.levelScriptableObjectList.levels.Length)
        {
            NextLevel(levelView.levelCount);
        }
    }

    public void NextLevel(int levelCount)
    {
      levelModel.levelNo = levelView.levelScriptableObjectList.levels[levelCount].levelNo;
      levelModel.levelTitle = levelView.levelScriptableObjectList.levels[levelCount].levelTitle;
      levelModel.levelSpriteElement = levelView.levelScriptableObjectList.levels[levelCount].levelSpriteElement;

       levelView.level.SetUI(levelView.levelScriptableObjectList.levels[levelCount].levelNo.ToString(),
       levelView.levelScriptableObjectList.levels[levelCount].levelTitle,
       levelView.levelScriptableObjectList.levels[levelCount].levelSpriteElement);
        
    }
}
