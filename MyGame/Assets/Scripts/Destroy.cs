using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    // creates event 
    public event OnDestroy DestryCallBack;
    // bool to determain if the object should be destroyed
    private bool gone;
    // represents the value of how far off the screen the object has 
    // to be before it is destroyed
    public float offset = 16f;
    private float gonex = 0f;
    // stores ridgedbody2d value
    private Rigidbody2D body2d;
    public delegate void OnDestroy();
    void Awake()
    {
        // sets ridgidody2d value
        body2d = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        // sets gonex 
        gonex = (Screen.width / PixelPervectCamera.pixelToUnits) / 2 * offset;
	}
	
	// Update is called once per frame
	void Update () {
        // creates variables to keeps track of positions
        var posX = transform.position.x;
        var dirY = body2d.velocity.x;
        // if absolute value of posX is greater then goneX 
        if (Mathf.Abs(posX) > gonex)
        {
            // checks if goin of the right or left side of the screen
            if (dirY < 0 && posX < -gonex)
            {
                gone = true;
            }else if(dirY > 0 && posX > gonex){
                gone = true;
            }
            else
            {
                gone = false;
            }
            // checks if gone is true
            if(gone){
                OnOutOfBounds();
            }
        }
    }
    public void OnOutOfBounds()
    {   // sets gone to false
        gone = false;
        // calling gameobjectutil to destroy object
        GameObjectUtil.Destroy(gameObject);
        // checks for not null
        if (DestryCallBack != null)
        {   
            // calls method
            DestryCallBack();
        }
    }
    
}
