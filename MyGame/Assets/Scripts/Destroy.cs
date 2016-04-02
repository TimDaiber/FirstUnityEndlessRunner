using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    public float offset = 16f;

    private bool gone;
    private float gonex = 0f;
    private Rigidbody2D body2d;

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        gonex = (Screen.width / PixelPervectCamera.pixelToUnits) / 2 * offset;
	}
	
	// Update is called once per frame
	void Update () {
        var posX = transform.position.x;
        var dirY = body2d.velocity.x;

        if (Mathf.Abs(posX) > gonex)
        {
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

            if(gone){
                OnOutOfBounds();
            }
        }
    }
    public void OnOutOfBounds()
    {
        gone = false;
        GameObjectUtil.Destroy(gameObject);
    }
}
