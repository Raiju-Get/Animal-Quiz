using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameStateMachine _currentState;
    private GameStateMachine _previousState;

    private GameStateMachine _playState = new PlayState();

    private GameStateMachine _pauseState = new PauseState();

    private GameStateMachine _winState = new WinState();
    private GameStateMachine _loseState = new LoseState();

    [SerializeField] private GameObject nextLevelPanel;
    [SerializeField] private GameObject winnerPanel;
    [SerializeField] private GameObject loserPanel;
    [SerializeField] private GameObject correctPanel;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite incorrectAnswerSprite;
    [SerializeField] Sprite normalSprite;
   
    [Header("Quiz Manager")]
    [SerializeField]private QuizManager _quizManager;

    [SerializeField] private int numberOfQuestion;
    
    public QuizManager QuizManager { get=>_quizManager; set=>_quizManager=value; }
    [SerializeField] int lives;

    public Sprite CorrectAnswerSprite
    {
        get => correctAnswerSprite;
        set=>correctAnswerSprite=value;
    }

    public Sprite IncorrectAnswerSprite
    {
        get => incorrectAnswerSprite;
        set => incorrectAnswerSprite = value;
    }
    public Sprite NormalSprite
    {
        get => normalSprite;
        set => normalSprite = value;
    }

    public SceneManagement sceneManagement;
    public int NumOfQuestion
    {
        get => numberOfQuestion;
        set => numberOfQuestion = value;
    }

    public GameStateMachine WinStateValue
    {
        get => _winState;
        set => _winState = value;
    }
    public GameStateMachine LoseStateValue
    {
        get => _loseState;
        set => _loseState = value;
    }

    public GameObject NextLevelPanel
    {
        get => nextLevelPanel;
        set => nextLevelPanel = value;
    }

    public GameObject WinnerPanel
    {
        get => winnerPanel;
        set => winnerPanel = value;
    }



    public GameObject LoserPanel
    {
        get => loserPanel;
        set => loserPanel = value;
    }
    public GameObject CorrectPanel
    {
        get => correctPanel;
        set => correctPanel = value;
    }

    public LivesManager livesManager;
    public ScoreManager scoreManager;

    private void Start()
    {
        lives = livesManager.currenntLives;
        StartGame();
    }

    public void StartGame()
    {
        numberOfQuestion = _quizManager.NumberOfQuestion();
        ChangeState(_playState);
    }



    private void Update()
    {
        if (_currentState!= null)
        {
            _currentState.UpdateState(this);
        }
    }


    public void ChangeState(GameStateMachine state)
    {
        if (_currentState!= null)
        {
            _previousState = _currentState;
            _currentState.EndState(this);
        }

        if (state!=null)
        {
            _currentState = state;
            _currentState.Startstate(this);
        }
    }

 
}
