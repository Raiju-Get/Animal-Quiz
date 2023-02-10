using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class QuizManager : MonoBehaviour
{
    [FormerlySerializedAs("levelArray")] [SerializeField] private List<LevelSO> levelList = new List<LevelSO>();
    [SerializeField]private List<QuestionSO> questionList = new List<QuestionSO>();
    [SerializeField]private Button[] buttonArray = new Button[4];
    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Image spriteImage;
    [Range(1,5)]
    [SerializeField] private int levelCounter;

    [SerializeField] private GameManager _gameManager;


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
        if (levelCounter <=4)
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
            for (int i = 0; i < questionList[randomQuestion].answerArray.Length; i++)
            {
                buttonArray[i].GetComponentInChildren<TextMeshProUGUI>().text =
                    questionList[randomQuestion].answerArray[i].answer;
            }
            inputManager.GetAnswer(questionList[randomQuestion].answerArray[questionList[randomQuestion].correctIndex].answer);
            spriteImage.sprite = questionList[randomQuestion].answerArray[questionList[randomQuestion].correctIndex]
                .image;
            questionList.RemoveAt(randomQuestion);
      
    }

    
}

