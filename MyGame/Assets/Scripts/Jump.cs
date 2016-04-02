using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    public float jspeed = 240f;
    public float fspeed = 20;




    private Rigidbody2D body2d;
    private InputState inputState;


        void Awake()
        {
            body2d = GetComponent<Rigidbody2D>();
            inputState = GetComponent<InputState>();
        }
	
	// Update is called once per frame
	void Update () {
        if (inputState.standing)
        {
            if (inputState.actionButton)
            {
                body2d.velocity = new Vector2(transform.position.x <0 ? fspeed : 0, jspeed);
            }
        }
	}
}
