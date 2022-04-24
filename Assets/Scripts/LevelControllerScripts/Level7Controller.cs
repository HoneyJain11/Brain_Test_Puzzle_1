using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Level7Controller : MonoBehaviour
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
    [SerializeField]
     GameObject crossSign;
 
    private void Start()
    {
        SetUI();
        submitBtn.onClick.AddListener(CheckAnswer);
    }

    private void SetUI()
    {
        levelNo.text = setLevelno;
        levelTitle.text = setLevelName;
        playPanel.SetActive(true);
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
            //Wrong Animations
            WrongAnswer();
            
        }
    }
    private  void WrongAnswer()
    {
        EventHandler.Instance.InvokeOnIncorrectInput(inputField.transform.position);

        /* GameObject cross = Instantiate(crossSign);
         cross.transform.localPosition = inputField.transform.position;
         cross.SetActive(true);
         Handheld.Vibrate();
         await new WaitForSeconds(0.5f);
         inputField.text = "";
         cross.SetActive(false);*/

    }

}
