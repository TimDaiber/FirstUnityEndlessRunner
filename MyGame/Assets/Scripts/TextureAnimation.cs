using UnityEngine;
using System.Collections;

public class TextureAnimation : MonoBehaviour {

    //creates properties that represent the speed the animation will be animated in
    public Vector2 speed = Vector2.zero;
    // keeps track of the the default offset position of the texture
    private Vector2 offset = Vector2.zero;
    // stores reference to the material
    private Material material;

	// Use this for initialization
	void Start () {
        //gets reference of the material of the quad
        material = GetComponent<Renderer>().material;
        // sets up offset
        // points to the materials own offset
        offset = material.GetTextureOffset("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {
        //increments the offset
        offset += speed * Time.deltaTime;
        // applies the incremented offset to the material
        material.SetTextureOffset("_MainTex", offset);

	}
}
