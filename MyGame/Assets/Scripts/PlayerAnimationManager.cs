using UnityEngine;
using System.Collections;

public class PlayerAnimationManager : MonoBehaviour {
    // getting reference variable to animator
    private Animator animator;
    // getting reference variable to inputState
    private InputState inputState;
    void Awake()
    {
        // setting reference of the animator and input state by getting the componenets
        animator = GetComponent<Animator>();
        inputState = GetComponent<InputState>();

    }

	
	
	// Update is called once per frame
	void Update () {

        // setting variable running to true
        var running = true;
        // if player is off the screen and not in the air at the same time
        if(inputState.absVelX > 0 && inputState.absVelY < inputState.standingThreshold){
            // set running to false
            running = false;
            // setting animator (flag) to running (false
            animator.SetBool("Running", running);
        }
	}
}
