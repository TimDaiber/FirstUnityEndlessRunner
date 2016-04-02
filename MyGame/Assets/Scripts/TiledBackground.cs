using UnityEngine;
using System.Collections;

public class TiledBackground : MonoBehaviour {
    public int size = 32;


    public bool scaleHorizontally = true;
    public bool scaleVertically = true;
	void Start () {



        var newWidth = !scaleHorizontally ? 1 : Mathf.Ceil(Screen.width / (size * PixelPervectCamera.scale));
        var newHeight = !scaleVertically ? 1 : Mathf.Ceil(Screen.height / (size * PixelPervectCamera.scale));

        transform.localScale = new Vector3(newWidth * size, newHeight * size, 1);

        GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth , newHeight , 1);

	}
	

}
