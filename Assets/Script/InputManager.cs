using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class InputManager : MonoBehaviour
{
   [SerializeField] private string correctAnswer;
   [SerializeField] private QuizManager quizManager;
   public void checkAnswer(TextMeshProUGUI answer)
   {
      if (answer.text == correctAnswer)
      {
         Debug.Log(correctAnswer);
         quizManager.SetQuestion();
      }
      else
      {
         Debug.Log("Wrong!!");
         quizManager.SetQuestion();
      }
   }

   public void GetAnswer(string tempAnswer)
   { 
      correctAnswer = tempAnswer;
   }
   
}
