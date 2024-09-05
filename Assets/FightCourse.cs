using System.Collections.Generic;
using UnityEngine;

public class FightCourse : MonoBehaviour
{
    public UbhObjectPool pool;
    public HealthSystem healthSystem;
    public GameObject enemy;
    public bool transitionPhases;

    private bool phase1Triggered = false;  // Flag to track if the first phase has been triggered
    private bool phase2Triggered = false;  // Flag to track if the second phase has been triggered
    private bool victory = false;          // Flag to track if the enemy is defeated

    void Start()
    {
        pool = GameObject.Find("Pool").GetComponent<UbhObjectPool>();
        healthSystem = GetComponent<HealthSystem>();

        // Trigger the initial phase when the enemy is at full health
        TriggerInitialPhase();
    }

    void Update()
    {
        // Check if health is less than or equal to 400 and the first phase hasn't been triggered yet
        if (healthSystem.currentHealth <= 400 && !phase1Triggered)
        {
            phase1Triggered = true;  // Set the flag to true to prevent future triggers
            TriggerPhaseTransition(1);  // Call the method to handle the first phase transition
        }

        // Check if health is less than or equal to 200 and the second phase hasn't been triggered yet
        if (healthSystem.currentHealth <= 300 && !phase2Triggered)
        {
            phase2Triggered = true;  // Set the flag to true to prevent future triggers
            TriggerPhaseTransition(2);  // Call the method to handle the second phase transition
        }

        // Check if health is less than or equal to 0 and victory hasn't been declared yet
        if (healthSystem.currentHealth <= 0 && !victory)
        {
            victory = true;  // Set the flag to true to prevent future triggers
            TriggerPhaseTransition(3);  // Call the method to handle the victory
        }
    }

    // Method to handle phase transition logic
    private void TriggerPhaseTransition(int phaseNumber)
    {
        Debug.Log("trigger canvi fase " + phaseNumber);
        
        // Common logic for phase transitions (disable player movement, shooting, etc.)
        GetComponent<PlayerLimitations>().disablePlayerMovement();
        GetComponent<PlayerLimitations>().disablePlayerShooting();
        GetComponent<DialogSetUp>().enabled = true;
        GetComponent<DialogSetUp>().dialogueOnCourse = true;
        pool.ReleaseAllBullet();

        // Phase-specific logic
        if (phaseNumber == 1)
        {
            disableEnemyPhases();
        }
        else if (phaseNumber == 2)
        {
            disableEnemyPhases();
        }
        else if (phaseNumber == 3)
        {
            disableEnemyPhases();
        }
    }

    // Method to handle the initial phase transition logic when enemy is at full health
    private void TriggerInitialPhase()
    {
        Debug.Log("Initial phase triggered at full health");

        // Custom logic for the initial phase
        GetComponent<PlayerLimitations>().disablePlayerMovement();
        GetComponent<PlayerLimitations>().disablePlayerShooting();
        GetComponent<DialogSetUp>().enabled = true;
        GetComponent<DialogSetUp>().dialogueOnCourse = true;
        pool.ReleaseAllBullet();
        
        disableEnemyPhases();
    }

    void disableEnemyPhases()
    {
        enemy.GetComponent<EnemyPhasesController>().isPhase1Active = false;
        enemy.GetComponent<EnemyPhasesController>().isPhase2Active = false;
        enemy.GetComponent<EnemyPhasesController>().isPhase3Active = false;
    }
}
