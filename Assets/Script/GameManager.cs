using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameStateMachine _currentState;
    private GameStateMachine _previousState;

    private GameStateMachine _playState = new PlayState();

    private GameStateMachine _pauseState = new PauseState();

    private GameStateMachine _winState = new WinState();

    [SerializeField] private GameObject UIWinnner;

    [Header("Quiz Manager")]
    [SerializeField]private QuizManager _quizManager;

    [SerializeField] private int numberOfQuestion;
    
    public QuizManager QuizManager { get=>_quizManager; set=>_quizManager=value; }
    
    
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

    public GameObject UIWinner
    {
        get => UIWinnner;
        set => UIWinnner = value;
    }
    

    private void Start()
    {
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
