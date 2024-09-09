using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    public Slider healthBar;  // Reference to the UI Slider
    public float maxHealth;  // Maximum health value
    public float currentHealth;  // Current health value
    public TMP_Text hpText;
    private int currentDifficulty;

    void Start()
    {
        currentDifficulty = PlayerPrefs.GetInt("difficulty", 0);
        if(currentDifficulty==0)
        {
            maxHealth=500;
        }
        else if(currentDifficulty==1)
        {
            maxHealth=800;
        }
        else if(currentDifficulty==2)
        {
            maxHealth=1500;
        }
        Debug.Log ("max health after difficultuy choose: " + maxHealth);

        currentHealth = maxHealth;  // Initialize current health to maximum health
        UpdateHealthBar();  // Update the health bar to reflect the initial health
    }
    void Update(){
        hpText.text=currentHealth.ToString();
        Debug.Log ("HP: " + currentHealth);
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
