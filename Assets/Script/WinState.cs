using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : GameStateMachine
{
    public override void Startstate(GameManager gameManager)
    {
        if (gameManager!= null)
        {
           gameManager.UIWinner.SetActive(true);
        }
    }

    public override void UpdateState(GameManager gameManager)
    {
       
    }

    public override void TransistionState(GameManager gameManager)
    {
        throw new System.NotImplementedException();
    }

    public override void EndState(GameManager gameManager)
    {
        throw new System.NotImplementedException();
    }
}
