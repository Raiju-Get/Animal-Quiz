using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class QuizManager : MonoBehaviour
{
    [SerializeField] private List<LevelSO> levelList = new List<LevelSO>();
    [SerializeField]private List<QuestionSO> questionList = new List<QuestionSO>();
    [SerializeField]private Button[] buttonArray = new Button[4];
    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Image spriteImage;
    [Range(1,5)]
    [SerializeField] private int levelCounter;
    [SerializeField] TextMeshProUGUI correctAnswerText;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] AudioPlayer audioPlayer;
    Queue<AudioClip> audioQueue = new Queue<AudioClip>();
    

    [Range(0,5)]
    [SerializeField] float soundOffset;


    public int LevelCounter
    {
        get => levelCounter;
        set => levelCounter = value;
    }

    public Queue<AudioClip> AudioQueue
    {
        get => audioQueue;
        set => audioQueue = value;
    }
    public List<LevelSO> LevelList
    {
        get => levelList;
        private set => levelList = value;
    }

    public Button[] ButtonArray
    {
        get => buttonArray;
        set => buttonArray = value;
    }
    private void Awake()
    {
        LoadQuestion();
    }

    private void LoadQuestion()
    {
        foreach (var question in levelList[levelCounter - 1].questionArray)
        {
            questionList.Add(question);
        }
    }

    public void LoadNextLevel()
    {
        if (levelCounter <=levelList.Count)
        {
            levelCounter++;
            LoadQuestion();
            _gameManager.StartGame();
        }
      
    }
    public int NumberOfQuestion()
    {
        return questionList.Count;
    }

    
    public void SetQuestion()
    {
        
        int numberOfQuestion = questionList.Count;
        int randomQuestion = Random.Range(0, numberOfQuestion);
        question.text = questionList[randomQuestion].question;
        audioQueue.Enqueue(questionList[randomQuestion].questionClip);
        List<AnswerSO> tempAnswerHolder = new List<AnswerSO>();

        for (int i = 0; i < questionList[randomQuestion].answerArray.Length; i++)
        {
            tempAnswerHolder.Add(questionList[randomQuestion].answerArray[i]);
         }

        List<AnswerSO> ShuffledList = ShuffleList.ShuffleListItems<AnswerSO>(tempAnswerHolder.ToList());

        for (int i = 0; i < questionList[randomQuestion].answerArray.Length; i++)
        {
            buttonArray[i].GetComponentInChildren<TextMeshProUGUI>().text =  ShuffledList[i].answer;
            audioQueue.Enqueue(ShuffledList[i].audioClip);
            
        }

        AudioCaller();

        inputManager.GetAnswer(questionList[randomQuestion].answerArray[questionList[randomQuestion].correctIndex].answer,audioQueue, 
                                questionList[randomQuestion].answerArray[questionList[randomQuestion].correctIndex].audioClip);
        spriteImage.sprite = questionList[randomQuestion].answerArray[questionList[randomQuestion].correctIndex].image;
        SetCorrectAnswerText(questionList[randomQuestion].answerArray[questionList[randomQuestion].correctIndex].answer);


        questionList.RemoveAt(randomQuestion);
      
    }

    public void SetCorrectAnswerText(string correctAnswer)
    {
        correctAnswerText.text = "The Correct Answer is " + correctAnswer;
    }
    void AudioCaller()
    {
        if (audioQueue.Count > 0)
        {
            StartCoroutine(PlayAudio(audioQueue.Peek().length, audioQueue.Peek(), audioQueue));
        }
        
    }
    IEnumerator PlayAudio(float time, AudioClip audioClip, Queue<AudioClip> audioQueue)
    {
        audioPlayer.Play(audioClip);
        yield return new WaitForSeconds(time + soundOffset);
        try
        {
            audioQueue.Dequeue();
        }
        catch 
        {
            StopAllCoroutines();
        }         
        AudioCaller();
    }

    public void CoroutineCheck()
    {
        StopAllCoroutines();
    }
}

