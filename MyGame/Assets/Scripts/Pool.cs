using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Pool : MonoBehaviour {
    // creates reference of prefab
    public Recycle prefab;
    // creates list of Recycled Gameobjects
    private List<Recycle> poolinstance = new List<Recycle>();

    // creates an instance of an Recycled gameobject
    // vector 3 is passed in to determain the position
    private Recycle Create(Vector3 pos)
    {
        //create clone of prefab
        // instantiates Gameobject
        var clone = GameObject.Instantiate(prefab);
        // sets position of the clone
        clone.transform.position = pos;
        // checks if prefab instance is nested in prefab pool
        clone.transform.parent = transform;
        // adds clone to pool instance list
        poolinstance.Add(clone);
        // returns reference to created clone
        return clone;
    }
    // method to return the next object in the pool 
    public Recycle Next(Vector3 pos)
    {
        // creates container variable
        Recycle instance = null;
        // iterates over each game object
        foreach (var go in poolinstance)
        {
            //checks if gameObject is AudioSettings TooltipAttribute flase
            // gets reference to its own game object
            if (go.gameObject.activeSelf != true)
            {
                // sets instance to the gameobject 
                instance = go;
                // changes game object position
                instance.transform.position = pos;
            }
        }
        // if null creates new instance
        if (instance == null) { 
            // creates new instance
            instance = Create(pos);
        }
        // calls restart method on the instance
        instance.Restart ();
        // returns instance
        return instance;
    }

}
