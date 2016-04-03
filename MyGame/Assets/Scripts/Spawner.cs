using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    // creates an array that contains all different types of prefabs the spawner can contain
    public GameObject[] prefabs;
    // adds delay
    public float delay = 2.0f;
    // bool to see if spawner is active
    public bool active = true;
    // adds delay range witch obstacels will spawn in
    public Vector2 delayRange = new Vector2(1, 2);

	// Use this for initialization
	void Start () {
        // calls method
        RDelay();
        // coroutine can run indepenent of a normal loop
        // starts coroutine
        // passes in enemy generator method
        StartCoroutine (EnemyGenerator());
	}

    // needs to reurn interface IEnumerator
    IEnumerator EnemyGenerator()
    {
        // waits and executes after the delay
        yield return new WaitForSeconds(delay);
        // checks if spawner is active
        if (active)
        {
            // represents position where objects will spawn
            var newTransform = transform;
            // instantiates new prefab 
            // selects prefab array
            // selects one prefab at random
            GameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)],newTransform.position);
            // calls delay method
            RDelay();
        }
        StartCoroutine(EnemyGenerator());
    }
    // resets delay every time something new is spawned by the spawner
    void RDelay()
    {
        // sets delay to random delay range
        delay = Random.Range(delayRange.x, delayRange.y);
    }
	
}
