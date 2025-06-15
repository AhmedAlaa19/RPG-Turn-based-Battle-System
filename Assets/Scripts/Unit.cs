using UnityEngine;

public class Unit : Character
{
    public override void SetupHealth()
    {
        currentHealth = maxHealth;
    }

    public override void RecieveDamage(int dmgAmount)
    {
        currentHealth -= dmgAmount;
        Debug.Log($"{charName} took {dmgAmount} damage! Health: {currentHealth}");
    }

    public override void Heal(int healAmount)
    {
        currentHealth = currentHealth + healAmount;
        Debug.Log($"{charName} healed {healAmount}! Health: {currentHealth}");
    }

    public override int Attack(int id)
    {
        Debug.Log($"{charName} attacked with move {id}");
        return id; // Return damage amount or move ID
    }
}