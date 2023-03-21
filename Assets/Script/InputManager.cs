using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
   [SerializeField] private string correctAnswer;
   [SerializeField] private QuizManager quizManager;
   [SerializeField] private GameManager gameManager;
   [SerializeField] private AudioClip correctAnswerClip;
   [SerializeField] private AudioClip incorrectAnswerClip;
   [SerializeField] private AudioPlayer audioPlayer;
   [SerializeField] float bufferTimer;
   [SerializeField] AudioClip correctAnswerPrecoursor; 
   [SerializeField] AudioClip correctAnswerAudio;
   Queue<AudioClip> audioClips= new Queue<AudioClip>();
    Image currentImage;
    
   bool isCorrect;


    public void GetButton(Image thisImage)
    {
        currentImage= thisImage;
    }
    public void CheckAnswer(TextMeshProUGUI answer)
   {
        
        audioClips.Clear();
        quizManager.CoroutineCheck();
        if (answer.text == correctAnswer)
        {
            isCorrect= true;
            Debug.Log(correctAnswer);
            if (gameManager.NumOfQuestion <=0){return;}
            currentImage.sprite = gameManager.CorrectAnswerSprite;
            gameManager.scoreManager.AddScore();
            StartCoroutine(QuestionBuffer(correctAnswerClip.length,correctAnswerClip));
         
        }
        else
        {
            isCorrect= false;          
            if (gameManager.NumOfQuestion <=0) {return;}
            gameManager.livesManager.TakeLives();
            currentImage.sprite = gameManager.IncorrectAnswerSprite;
            StartCoroutine(QuestionBuffer(incorrectAnswerClip.length, incorrectAnswerClip));
        }
        gameManager.NumOfQuestion--;
    }

   


    IEnumerator QuestionBuffer(float time, AudioClip audioClip)
    {
        audioPlayer.Play(audioClip);
        ActivateButton(false);
        yield return new WaitForSeconds(time+ bufferTimer);
        currentImage.sprite = gameManager.NormalSprite;
        if (isCorrect)
        {
            CheckWinstate();
        }
        else
        {
            StartCoroutine(IncorrectAnswer());
        }

        
    }

    IEnumerator IncorrectAnswer()
    {
        audioPlayer.Play(correctAnswerPrecoursor);
        gameManager.CorrectPanel.SetActive(true);      
        yield return new WaitForSeconds(correctAnswerPrecoursor.length  +bufferTimer);
        audioPlayer.Play(correctAnswerAudio);
        Invoke("CheckWinstate", correctAnswerAudio.length + bufferTimer);
        
     
    }

    private void CheckWinstate()
    {
        if (gameManager.livesManager.currenntLives <= 0)
        {
            gameManager.ChangeState(gameManager.LoseStateValue);
        }
        else
        {
            if (gameManager.NumOfQuestion <= 0)
            {
                gameManager.ChangeState(gameManager.WinStateValue);
            }
            else
            {
                quizManager.SetQuestion();
            }         
        }
        gameManager.CorrectPanel.SetActive(false);
        ActivateButton(true);
    }

    public void ActivateButton(bool currentStauts)
    {
        for (int i = 0; i < gameManager.QuizManager.ButtonArray.Length; i++)
        {
            gameManager.QuizManager.ButtonArray[i].interactable = currentStauts;
        }
    }
    public void GetAnswer(string tempAnswer, Queue<AudioClip> audioQueue , AudioClip tempAudio)
   { 
      correctAnswer = tempAnswer;
      audioClips = audioQueue;
       correctAnswerAudio = tempAudio;
   }
   
}
