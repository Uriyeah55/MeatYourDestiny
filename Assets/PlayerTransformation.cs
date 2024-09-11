using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformation : MonoBehaviour
{
    private bool isVegState = true;  // Track the current state
    private Animator animator;       // Reference to Animator component

    // References to UbhShotCtrl components
    private UbhShotCtrl normalShotCtrl;
    private UbhShotCtrl transformedShotCtrl;

    void Start()
    {
        // Cache the Animator component for better performance
        animator = GetComponent<Animator>();

        // Find all UbhShotCtrl components in children
        UbhShotCtrl[] shotCtrls = GetComponentsInChildren<UbhShotCtrl>();

        if (shotCtrls.Length < 2)
        {
            Debug.LogError("Less than 2 UbhShotCtrl components found! Make sure there are two for normal and transformed shots.");
            return;
        }

        // Assign the first found UbhShotCtrl to normalShotCtrl and the second to transformedShotCtrl
        normalShotCtrl = shotCtrls[0];
        transformedShotCtrl = shotCtrls[1];

        // Start with normal shot enabled and transformed shot disabled
        if (normalShotCtrl != null) normalShotCtrl.StartShotRoutine(); // Start shooting in normal state
        if (transformedShotCtrl != null) transformedShotCtrl.StopShotRoutine(); // Ensure transformed state shooting is off
    }

    void Update()
    {
        // Check if the "M" key is pressed once
        if (Input.GetKeyDown(KeyCode.M))  // Changed to GetKeyDown
        {
            // Check the current state and switch to the other state
            if (isVegState)
            {
                animator.SetTrigger("normalToVegg");  // Trigger to switch to "veggie" state
                isVegState = false;  // Update state
                SwitchToTransformedShot();
            }
            else
            {
                animator.SetTrigger("VegToNormal");  // Trigger to switch to "normal" state
                isVegState = true;  // Update state
                SwitchToNormalShot();
            }
        }
    }

    void SwitchToNormalShot()
    {
        // Stop transformed shot and start normal shot
        if (transformedShotCtrl != null) transformedShotCtrl.StopShotRoutine();
        if (normalShotCtrl != null) normalShotCtrl.StartShotRoutine();
    }

    void SwitchToTransformedShot()
    {
        // Stop normal shot and start transformed shot
        if (normalShotCtrl != null) normalShotCtrl.StopShotRoutine();
        if (transformedShotCtrl != null) transformedShotCtrl.StartShotRoutine();
    }
}
