using UnityEngine;

public class StartState : IBattleState  // Correct interface name
{
    public void EnterState(BattleSystem battle)  // Exact signature match
    {
        Debug.Log("Battle initialized - Starting player turn");
        battle.TransitionToState(battle.playerTurnState);
    }

    public void UpdateState(BattleSystem battle) 
    {
         
    }

    public void ExitState(BattleSystem battle) 
    {
         
    }
}