public interface IBattleState {
    void EnterState(BattleSystem battle);
    void UpdateState(BattleSystem battle);
    void ExitState(BattleSystem battle);
}