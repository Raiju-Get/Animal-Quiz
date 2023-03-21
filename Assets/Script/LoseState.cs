using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : GameStateMachine
{
    public override void EndState(GameManager gameManager)
    {
       
    }

    public override void Startstate(GameManager gameManager)
    {
        if (gameManager != null)
        {
            Debug.Log("You Lose");
            gameManager.LoserPanel.SetActive(true);

        }
    }

    public override void TransistionState(GameManager gameManager)
    {
       
    }

    public override void UpdateState(GameManager gameManager)
    {
        
    }
}
