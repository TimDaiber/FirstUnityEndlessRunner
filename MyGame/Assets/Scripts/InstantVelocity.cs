using UnityEngine;
using System.Collections;

public class InstantVelocity : MonoBehaviour {

    // stores velocity of the object
    public Vector2 velocity = Vector2.zero;
    // creates ridged2d reference
    private Rigidbody2D body2d;

    void Awake()
    {
        // creates reference to the actual ridgid2d body 
        body2d = GetComponent<Rigidbody2D> ();
    }
    // special type of update reserved to make phisic calculations
    void FixedUpdate()
    {
        // sets  velocity 
        body2d.velocity = velocity;
    }

}
