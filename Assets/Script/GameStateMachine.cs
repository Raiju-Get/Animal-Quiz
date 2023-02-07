using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameStateMachine
{
    public abstract void Startstate(GameManager gameManager);
    public abstract void UpdateState(GameManager gameManager);
    public abstract void TransistionState(GameManager gameManager);
    public abstract void EndState(GameManager gameManager);
}
