using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    public Slider healthBar;  // Reference to the UI Slider
    [SerializeField] public float maxHealth;  // Default maxHealth value; can be adjusted
    public float currentHealth;  // Current health value
    public TMP_Text hpText;
    private int currentDifficulty;
    private bool initialized = false; // Flag to ensure initialization is done only once

    void Start()
    {
        InitializeHealth();  // Initialize maxHealth based on difficulty
        currentHealth = maxHealth;  // Initialize current health to maximum health
        UpdateHealthBar();  // Update the health bar to reflect the initial health
    }

    // Method to initialize health based on difficulty
    private void InitializeHealth()
    {
        if (initialized) return; // Prevent multiple initializations

        currentDifficulty = PlayerPrefs.GetInt("difficulty", 0);
        Debug.Log("Difficulty check: " + currentDifficulty);

        // Set maxHealth based on the difficulty level
        if (currentDifficulty == 1)
        {
            maxHealth = 2000f;
        }
        else if (currentDifficulty == 2)
        {
            maxHealth = 2500f;
        }
        else if (currentDifficulty == 3)
        {
            maxHealth = 3500f;
        }

        initialized = true; // Mark as initialized
        Debug.Log("Max health after difficulty choice: " + maxHealth);
    }

    void Update()
    {
        hpText.text = currentHealth.ToString();
        Debug.Log("HP: " + currentHealth);
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
