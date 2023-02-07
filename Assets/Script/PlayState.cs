using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : GameStateMachine
{
    

    public override void Startstate(GameManager gameManager)
    {
        gameManager.QuizManager.SetQuestion();
    }

    public override void UpdateState(GameManager gameManager)
    {
        if (gameManager.NumOfQuestion <= 0)
        {
            gameManager.ChangeState(gameManager.WinStateValue);
        }
       
    }

    public override void TransistionState(GameManager gameManager)
    {
        throw new System.NotImplementedException();
    }

    public override void EndState(GameManager gameManager)
    {
        Debug.Log("No longer Player: Play State");
    }
}
