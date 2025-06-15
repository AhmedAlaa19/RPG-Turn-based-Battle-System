using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class EnemyTurnState : IBattleState
{
    public void EnterState(BattleSystem battle)
    {
        Debug.Log("Enemy's Turn Started");
        EnemyAttackTask(battle);
    }

    public void UpdateState(BattleSystem battle) { }

    public void ExitState(BattleSystem battle)
    {
        Debug.Log("Enemy's Turn Ended");
    }


    private async void EnemyAttackTask(BattleSystem battle)
    {
        battle.enemyAnim.SetTrigger("Attack");
        
        
        await Cooldown(200);
        battle.playerUnit.RecieveDamage(20);
        battle.playerAnim.SetTrigger("Hit");
        await Cooldown(500);
        battle.playerAnim.Play("Idle");
        battle.enemyAnim.Play("Idle");
        battle.TransitionToState(battle.playerTurnState);
        battle.canPlayerAttack = true;
     
    }

    private async Task Cooldown(int Cooldown)
    {
        await Task.Delay(Cooldown);
    }
}