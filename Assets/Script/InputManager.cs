using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class InputManager : MonoBehaviour
{
   [SerializeField] private string correctAnswer;
   [SerializeField] private QuizManager quizManager;
   [SerializeField] private GameManager gameManager;

    private void Start()
    {
    }

    public void checkAnswer(TextMeshProUGUI answer)
   {
      gameManager.NumOfQuestion--;
      if (answer.text == correctAnswer)
      {
         Debug.Log(correctAnswer);
         if (gameManager.NumOfQuestion <=0)
         {
            return;
         }
         quizManager.SetQuestion();
      }
      else
      {
         if (gameManager.NumOfQuestion <=0)
         {
            return;
         }
         quizManager.SetQuestion();
      }
    

      
   }

   public void GetAnswer(string tempAnswer)
   { 
      correctAnswer = tempAnswer;
   }
   
}
