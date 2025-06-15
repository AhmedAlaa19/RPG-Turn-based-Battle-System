using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public string charName;
    public int maxHealth = 100;
    public int currentHealth = 100;

    public abstract void SetupHealth();
    public abstract void RecieveDamage(int dmgAmount);
    public abstract void Heal(int healAmount);
    public abstract int Attack(int id);
}