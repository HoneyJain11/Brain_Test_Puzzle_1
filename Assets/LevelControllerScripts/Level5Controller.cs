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
            playPanel.SetActive(false);
        }
        else
        {
            Debug.Log("Wrong Answer");
            //Wrong Animations
            inputField.text = "";
        }
    }

    private void SetUI()
    {
        levelNo.text = "Level : 5";
        levelTitle.text = "Solve The Equation";
        playPanel.SetActive(true);
    }



}
