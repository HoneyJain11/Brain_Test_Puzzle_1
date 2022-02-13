
using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class LevelView : MonoBehaviour
{
    public LevelController levelController;
    //public ParticleSystem correctTouchParticleSystem;
    public TextMeshProUGUI levelNoText;
    public TextMeshProUGUI levelTitleText;
    private LevelScriptableObject levelScriptableObject;
    public LevelView levelView;
    public LevelModel model;
    public LevelController level;
    public GameObject levelSprite;
    public LevelScriptableObjectList levelScriptableObjectList;
    public int levelCount = 0;

    private void Start()
    {
        StartGame();  
    }

    private void StartGame()
    {
        levelController = new LevelController();
        levelController = CreateLevel(levelCount);
        levelController.SetUI();
    }

    public LevelController CreateLevel(int levelCount)
    {
        levelScriptableObject = levelScriptableObjectList.levels[levelCount];
        model = new LevelModel(levelScriptableObject);
        level = new LevelController(model,levelView);
        return level;
    }
   /* public void NextLevel(int levelCount)
    {        
        model.levelNo = levelScriptableObjectList.levels[levelCount].levelNo;
        model.levelTitle = levelScriptableObjectList.levels[levelCount].levelTitle;
        model.levelSpriteElement = levelScriptableObjectList.levels[levelCount].levelSpriteElement;

        level.SetUI(levelScriptableObjectList.levels[levelCount].levelNo.ToString(),
            levelScriptableObjectList.levels[levelCount].levelTitle,
            levelScriptableObjectList.levels[levelCount].levelSpriteElement);
    }*/


    public void GameObjectDestory()
    {
     //   Destroy(levelSprite);
    }

    private void Update()
    {
        levelController.DetectGameObject();
    }
}

