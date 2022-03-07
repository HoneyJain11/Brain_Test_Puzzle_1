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
        levelNo.text = "Level : 7";
        levelTitle.text = "Counts the Flower";
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
            playPanel.SetActive(false);
        }
        else
        {
            Debug.Log("Wrong Answer");
            //Wrong Animations
            Vector3 pos = inputField.transform.position;
            pos.z = 0f;
            WrongAnswer(pos);
            
        }
    }
    private async void WrongAnswer(Vector2 position)
    {
       GameObject cross =  Instantiate(crossSign, position, Quaternion.identity,transform.parent.parent);
        cross.transform.localPosition = position;
        cross.SetActive(true);
        //position.z = 0f;
        
        Handheld.Vibrate();
        await new WaitForSeconds(0.5f);
        inputField.text = "";
        //crossSign.SetActive(false);

    }
}
