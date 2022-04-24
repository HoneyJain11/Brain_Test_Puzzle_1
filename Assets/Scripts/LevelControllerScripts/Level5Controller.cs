using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Level5Controller : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI levelNo;
    [SerializeField]
    TextMeshProUGUI levelTitle;
    [SerializeField]
    Image questionImage;
    [SerializeField]
    TMP_InputField inputField;
    [SerializeField]
    Button submitBtn;
    [SerializeField]
    string correctAnswer;
    [SerializeField] string setLevelName;
    [SerializeField] string setLevelno;
    [SerializeField]
    GameObject playPanel;
    private void Start()
    {
        SetUI();
        submitBtn.onClick.AddListener(CheckAnswer);
    }


    public void CheckAnswer()
    { 
        if (inputField.text == correctAnswer)
        {

            Debug.Log("Correct Answer");
            //correct Animation
            //particle Effect
            //levelComplete
            //Win panel
            inputField.text = "";
            playPanel.SetActive(false);
            EventHandler.Instance.InvokeOnCompleteLevel();
        }
        else
        {
            Debug.Log("Wrong Answer");
            Vector3 pos = inputField.GetComponent<RectTransform>().position;
            EventHandler.Instance.InvokeOnIncorrectInput(pos);
            //Wrong Animations
            inputField.text = "";
           
        }
    }

    private void SetUI()
    {
        levelNo.text = setLevelno;
        levelTitle.text = setLevelName;
        playPanel.SetActive(true);
    }



}
