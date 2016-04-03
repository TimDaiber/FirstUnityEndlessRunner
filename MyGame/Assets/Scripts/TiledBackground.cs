using UnityEngine;
using System.Collections;

public class TiledBackground : MonoBehaviour {
    // creating public variables
    public int size = 32;
    public bool scaleHorizontally = true;
    public bool scaleVertically = true;

	void Start () {
        // calulating new width and height
        // rounds up to the highest value number using Math class and ceil
        // 
        var newWidth = !scaleHorizontally ? 1 : Mathf.Ceil(Screen.width / (size * PixelPervectCamera.scale));
        var newHeight = !scaleVertically ? 1 : Mathf.Ceil(Screen.height / (size * PixelPervectCamera.scale));
        //changes the scale of the quad based on new width and new height
        transform.localScale = new Vector3(newWidth * size, newHeight * size, 1);
        // Tells new material that it has a new scale
        // gets component renderer 
        // get reference of the material and gets the new scale
        GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth , newHeight , 1);

	}
	

}
