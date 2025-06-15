using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    // State References
    public StartState startState = new StartState();
    public PlayerTurnState playerTurnState = new PlayerTurnState();
    public EnemyTurnState enemyTurnState = new EnemyTurnState();
    private IBattleState currentState;

    public Animator playerAnim;
    public Animator enemyAnim;
    public Slider enemySlider;
    public Slider playerSlider;



    // Unit References
    public Unit playerUnit;
    public Unit enemyUnit;



    public bool canPlayerAttack;
    [SerializeField] private Unit victimUnit; // Now serialized for editor assignment

    void Awake()
    {

        currentState = startState;
        currentState.EnterState(this);
    }

    void Start()
    {

        if (!playerUnit) playerUnit = GameObject.FindGameObjectWithTag("Player").GetComponent<Unit>();
        if (!enemyUnit) enemyUnit = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Unit>();
        if (!playerAnim) playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        if (!enemyAnim) enemyAnim = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
         




        TransitionToState(playerTurnState);
        canPlayerAttack = true;
    }

    void Update()
    {
        currentState.UpdateState(this);
        enemySlider.value = enemyUnit.currentHealth;
        playerSlider.value = playerUnit.currentHealth;

 
    }

    void OnEnable()
    {
        MakeButton.melee.AddListener(OnMelee);
        MakeButton.ranged.AddListener(OnRanged);
        MakeButton.heal.AddListener(OnHeal);
    }

    void OnDisable()
    {
        MakeButton.melee.RemoveListener(OnMelee);
        MakeButton.ranged.RemoveListener(OnRanged);
        MakeButton.heal.RemoveListener(OnHeal);
    }

    public void TransitionToState(IBattleState newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }


    async void OnMelee()
    {
        if (currentState is PlayerTurnState && canPlayerAttack)
        {
            canPlayerAttack = false;
            playerAnim.SetTrigger("Melee");
            
            await PlayerCooldown(200);
            enemyUnit.RecieveDamage(30);
            enemyAnim.SetTrigger("Hit");
            await PlayerCooldown(500);
          
            playerAnim.Play("Idle");
            enemyAnim.Play("Idle");
            TransitionToState(enemyTurnState);
           
        }
    }

    async void OnRanged()
    {
        if (currentState is PlayerTurnState && canPlayerAttack)
        {
            canPlayerAttack = false;
            playerAnim.SetTrigger("Ranged");
            await PlayerCooldown(300);
            enemyUnit.RecieveDamage(30);
            enemyAnim.SetTrigger("Hit");
            await PlayerCooldown(500);
    
            playerAnim.Play("Idle");
            enemyAnim.Play("Idle");
            TransitionToState(enemyTurnState);
            
        }
    }

    async void OnHeal()
    {
        if (currentState is PlayerTurnState && canPlayerAttack)
        {
            canPlayerAttack = false;
            playerUnit.Heal(30);
            await PlayerCooldown(200);
            
            playerAnim.Play("Idle");
            enemyAnim.Play("Idle");
            TransitionToState(enemyTurnState);
            
        }
    }

    private async Task PlayerCooldown(int Cooldown)
    {
        await Task.Delay(Cooldown);
    }
}