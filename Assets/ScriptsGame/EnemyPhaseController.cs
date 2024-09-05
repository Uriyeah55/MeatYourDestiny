using UnityEngine;

public class EnemyPhasesController : MonoBehaviour
{
    private UbhShotCtrl[] shotControllers; // Array to hold all UBH Shot Controllers
    private UbhShotCtrl phase1ShotController;
    private UbhShotCtrl phase2ShotController;
    private UbhShotCtrl phase3ShotController; // Third UBH Shot Controller

    public bool isPhase1Active = true;  // Boolean variable to control Phase 1
    public bool isPhase2Active = false; // Boolean variable to control Phase 2
    public bool isPhase3Active = false; // Boolean variable to control Phase 3

    private bool isPhase1Shooting = false;  // Internal state to track if Phase 1 is shooting
    private bool isPhase2Shooting = false;  // Internal state to track if Phase 2 is shooting
    private bool isPhase3Shooting = false;  // Internal state to track if Phase 3 is shooting

    void Start()
    {
        // Get all UBH Shot Controllers attached to this GameObject
        shotControllers = GetComponents<UbhShotCtrl>();

        if (shotControllers.Length >= 3)
        {
            // Assign each shot controller to a variable
            phase1ShotController = shotControllers[0];  // First UBH Shot Controller
            phase2ShotController = shotControllers[1];  // Second UBH Shot Controller
            phase3ShotController = shotControllers[2];  // Third UBH Shot Controller
        }
        else
        {
            Debug.LogError("Not enough UBH Shot Controllers on this GameObject.");
            return;
        }
    }

    void Update()
    {
        // Check if Phase 1 should be active
        if (isPhase1Active && !isPhase1Shooting)
        {
            ActivatePhase1();
        }
        else if (!isPhase1Active && isPhase1Shooting)
        {
            DeactivatePhase1();
        }

        // Check if Phase 2 should be active
        if (isPhase2Active && !isPhase2Shooting)
        {
            ActivatePhase2();
        }
        else if (!isPhase2Active && isPhase2Shooting)
        {
            DeactivatePhase2();
        }

        // Check if Phase 3 should be active
        if (isPhase3Active && !isPhase3Shooting)
        {
            ActivatePhase3();
        }
        else if (!isPhase3Active && isPhase3Shooting)
        {
            DeactivatePhase3();
        }
    }

    // Method to activate Phase 1 shooting
    void ActivatePhase1()
    {
        phase1ShotController.StartShotRoutine();  // Start shooting for Phase 1
        isPhase1Shooting = true;  // Update internal state
        isPhase2Shooting = false; // Ensure Phase 2 state is false
        isPhase3Shooting = false; // Ensure Phase 3 state is false
    }

    // Method to deactivate Phase 1 shooting
    void DeactivatePhase1()
    {
        phase1ShotController.StopShotRoutine();  // Stop shooting for Phase 1
        isPhase1Shooting = false;  // Update internal state
    }

    // Method to activate Phase 2 shooting
    void ActivatePhase2()
    {
        phase2ShotController.StartShotRoutine();  // Start shooting for Phase 2
        isPhase2Shooting = true;  // Update internal state
        isPhase1Shooting = false; // Ensure Phase 1 state is false
        isPhase3Shooting = false; // Ensure Phase 3 state is false
    }

    // Method to deactivate Phase 2 shooting
    void DeactivatePhase2()
    {
        phase2ShotController.StopShotRoutine();  // Stop shooting for Phase 2
        isPhase2Shooting = false;  // Update internal state
    }

    // Method to activate Phase 3 shooting
    void ActivatePhase3()
    {
        phase3ShotController.StartShotRoutine();  // Start shooting for Phase 3
        isPhase3Shooting = true;  // Update internal state
        isPhase1Shooting = false; // Ensure Phase 1 state is false
        isPhase2Shooting = false; // Ensure Phase 2 state is false
    }

    // Method to deactivate Phase 3 shooting
    void DeactivatePhase3()
    {
        phase3ShotController.StopShotRoutine();  // Stop shooting for Phase 3
        isPhase3Shooting = false;  // Update internal state
    }
}
