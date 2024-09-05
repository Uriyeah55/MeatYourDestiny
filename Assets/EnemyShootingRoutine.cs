using System.Collections;
using UnityEngine;

public class EnemyShootingRoutine : MonoBehaviour
{
    public GameObject pattern1;  // Assign the pattern GameObjects in the inspector
    public GameObject pattern2;
    public GameObject pattern3;

    public float patternDuration = 5f;  // Time in seconds for each pattern
    private int currentPatternIndex = 0;

    private GameObject[] patterns;  // Array to hold all patterns

    void Start()
    {
        // Initialize the pattern array
        patterns = new GameObject[] { pattern1, pattern2, pattern3 };

        // Start the shooting routine
        StartCoroutine(ShootingRoutine());
    }

    IEnumerator ShootingRoutine()
    {
        while (true)  // Infinite loop to keep the sequence going
        {
            // Activate the current pattern
            patterns[currentPatternIndex].SetActive(true);

            // Wait for the duration of the pattern
            yield return new WaitForSeconds(patternDuration);

            // Deactivate the current pattern
            patterns[currentPatternIndex].SetActive(false);

            // Move to the next pattern
            currentPatternIndex = (currentPatternIndex + 1) % patterns.Length;  // Loop back to the first pattern if at the end
        }
    }
}
