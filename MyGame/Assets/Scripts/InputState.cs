using UnityEngine;
using System.Collections;

public class InputState : MonoBehaviour {
    // creating variables
    public bool actionButton;
    public float absVelX = 0f;
    public float absVelY = 0f;
    // bool to determain if player is standing
    public bool standing;
    // Keeps track of velosity (if standing or not)
    public float standingThreshold = 1;
    // Creates a Reference
    private Rigidbody2D body2d;

    void Awake()
    {
        // gets component of Ridgid coponent
        body2d = GetComponent<Rigidbody2D>();

    }
	
	
	// Update is called once per frame
	void Update () {
        // allows player jump on any key
        actionButton = Input.anyKeyDown;
	}

    // calculates if player is standing or not
    void FixedUpdate()
    {
        // convert values to absolute values
        absVelX = System.Math.Abs(body2d.velocity.x);
        absVelY = System.Math.Abs(body2d.velocity.y);
        // tests if player is standing
        //if not moving on y axis = standing
        standing = absVelY <= standingThreshold;
    }
}
