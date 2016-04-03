using UnityEngine;
using System.Collections;

// implements IRecycle interface
public class Obstacles : MonoBehaviour, IRecycle {

    // creates an array of sprites
    public Sprite[] sprites;
    // keeps track of offset of collid
    public Vector2 colliderOffset = Vector2.zero;
    // implements IRecycle method Restart
    public void Restart()
    {
        // gets reference of sprite renderer
        var renderer = GetComponent<SpriteRenderer>();
        // gets a random sprite
        renderer.sprite = sprites[Random.Range(0, sprites.Length)];
        //gets reference of bocCollider2D component
        var collider = GetComponent<BoxCollider2D>();
        // sets size to size of sprite
        var size  = renderer.bounds.size;

        // changes the size 
        size.y += colliderOffset.y;
        // sets colliders size to new size
        collider.size = size;

        collider.offset = new Vector2(-colliderOffset.x, collider.size.y / 2 - colliderOffset.y);
    }
    // implements IRecycle method shutdown
    public void ShutDown()
    {
        
    }
}
