using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class QuizManager : MonoBehaviour
{
    [SerializeField]private List<QuestionSO> questionList = new List<QuestionSO>();
    [SerializeField]private Button[] buttonArray = new Button[4];
    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private InputManager inputManager;

    private void Start()
    {
     SetQuestion();   
    }

    public void SetQuestion()
    {
        int numberOfQuestion = questionList.Count;
        int randomQuestion = Random.Range(0, numberOfQuestion);
        question.text = questionList[randomQuestion].question;
        for (int i = 0; i < questionList[randomQuestion].answerArray.Length; i++)
        {
            buttonArray[i].GetComponentInChildren<TextMeshProUGUI>().text =
                questionList[randomQuestion].answerArray[i].answer;
        }
        inputManager.GetAnswer(questionList[randomQuestion].answerArray[questionList[randomQuestion].correctIndex].answer);
        questionList.RemoveAt(randomQuestion);
    }

    
}

