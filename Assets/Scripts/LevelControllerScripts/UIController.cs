using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject levelCompletePanel;
    [SerializeField] Button homeButton;
    [SerializeField] Button nextButton;
    [SerializeField] GameObject[] levelList;
    int counter = 0;

    void Start()
    {
       
        SubscribeEvent();
        homeButton.onClick.AddListener(OnHomeButtonClick);
        nextButton.onClick.AddListener(() => EventHandler.Instance.InvokeOnNextButton());
    }




    void OpenNextLevel()
    {
        if (counter < levelList.Length-1)
        {
            levelList[counter].SetActive(false);
            counter++;
            levelList[counter].SetActive(true);
            levelCompletePanel.SetActive(false);
        }
        else
        {
            counter = 0;
            levelList[counter].SetActive(true);
        }
        

    }

    void OpenLevelCompletePanel()
    {
        levelCompletePanel.SetActive(true);

    }
     void OnHomeButtonClick()
    {
        SceneManager.LoadScene(0);

    }

    void SubscribeEvent()
    {
        EventHandler.Instance.OnCompleteLevel += OpenLevelCompletePanel;
        EventHandler.Instance.OnNextButton += OpenNextLevel;
        EventHandler.Instance.OnIncorrectInput += SpwanCrossSign;
    }

    private async void SpwanCrossSign(Vector3 position)
    {
        GameObject cross = ObjectPooler.Instance.GetPooledObject();
        cross.SetActive(true);
        position.z = 0;
        cross.transform.position = position;
        Handheld.Vibrate();
        await new WaitForSeconds(0.5f);
        cross.SetActive(false);

    }

    void UnsubscribeEvent()
    {
        EventHandler.Instance.OnCompleteLevel -= OpenLevelCompletePanel;
        EventHandler.Instance.OnNextButton -= OpenNextLevel;
        EventHandler.Instance.OnIncorrectInput -= SpwanCrossSign;

    }
    private void OnDisable()
    {
        UnsubscribeEvent();
    }
}
