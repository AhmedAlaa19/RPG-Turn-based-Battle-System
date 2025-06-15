using UnityEngine;

public class PlayerTurnState : IBattleState
{
    public void EnterState(BattleSystem battle)
    {
        Debug.Log("Player's Turn Started");

    }

    public void UpdateState(BattleSystem battle)
    {
  
    }

    public void ExitState(BattleSystem battle)
    {
        Debug.Log("Player's Turn Ended");
    }
}