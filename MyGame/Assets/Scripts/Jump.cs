using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
    // setting variable to determain jump speed and forward jump distance
    public float jspeed = 240f;
    public float fspeed = 20;
    // creating references 
    private Rigidbody2D body2d;
    private InputState inputState;


        void Awake()
        {
            //setting variable to there components
            body2d = GetComponent<Rigidbody2D>();
            inputState = GetComponent<InputState>();
        }
	
	// Update is called once per frame
	void Update () {
        // if player is standing
        if (inputState.standing)
        {
            // if action button pressed
            if (inputState.actionButton)
            {
                // making the player jump up and forward
                body2d.velocity = new Vector2(transform.position.x < 0 ? fspeed : 0, jspeed);
            }
        }
	}
}
