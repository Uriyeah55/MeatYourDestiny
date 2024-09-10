using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformation : MonoBehaviour
{
    private bool isVegState = true;  // Track the current state
    private Animator animator;       // Reference to Animator component

    void Start()
    {
        // Cache the Animator component for better performance
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the "M" key is pressed
        if (Input.GetKey(KeyCode.M))
        {
            // Check the current state and switch to the other state
            if (isVegState)
            {
                animator.SetTrigger("VegToNormal");  // Trigger to switch to "normal" state
                isVegState = false;  // Update state
            }
            else
            {
                animator.SetTrigger("normalToVegg");  // Trigger to switch to "veggie" state
                isVegState = true;  // Update state
            }
        }
    }
}
