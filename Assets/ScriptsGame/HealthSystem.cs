using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Slider healthBar;  // Reference to the UI Slider
    public float maxHealth = 500f;  // Maximum health value
    public float currentHealth;  // Current health value

    void Start()
    {
        currentHealth = maxHealth;  // Initialize current health to maximum health
        UpdateHealthBar();  // Update the health bar to reflect the initial health
    }

    // Method to take damage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;  // Reduce current health by damage amount
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Ensure health does not go below 0
        UpdateHealthBar();  // Update the health bar UI
    }

    // Method to heal
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;  // Increase current health by heal amount
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Ensure health does not exceed max health
        UpdateHealthBar();  // Update the health bar UI
    }

    // Method to update the health bar UI
    private void UpdateHealthBar()
    {
        healthBar.value = currentHealth / maxHealth;  // Normalize the health value between 0 and 1
    }
}
