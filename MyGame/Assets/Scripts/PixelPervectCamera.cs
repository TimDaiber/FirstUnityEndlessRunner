using UnityEngine;
using System.Collections;

public class PixelPervectCamera : MonoBehaviour {

    // Creating Public static variables
    public static float pixelToUnits = 1f;
    public static float scale = 1f;

    // Creating public vector 2 defines the native resolution of the game 
	public Vector2 nativeResolution = new Vector2 (240, 160);
	
    // Awake method calculate the difference of the scale of the device we want to play the game on

    void Awake () {
        // reference to the camera we are playin on
        var camera = GetComponent<Camera>();
        // sets camera into ortographic
        // if in ortographic
        // since the game was created in 2D mode ortographic is automatically set for the game
        if (camera.orthographic)
        {
            //takes the current screen height and devides it by the native resolution of the game
            // stores answere into scale variable          
            scale = Screen.height / nativeResolution.y;
            pixelToUnits *= scale;
            // changes size of the ortographic camera
            camera.orthographicSize = (Screen.height / 2.0f) / pixelToUnits;
        }
	}
	

}
