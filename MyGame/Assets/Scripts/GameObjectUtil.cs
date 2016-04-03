using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectUtil  {
    // creates dictionary
    // manages instances it creates
    private static Dictionary<Recycle, Pool> pools = new Dictionary<Recycle, Pool>();
    //creates method and instantiates it by using vector 3
    public static GameObject Instantiate(GameObject prefab, Vector3 pos)
    {
        // creates container variable
        GameObject instance = null;
        // sets variable to prefab component 
        var recycleScript = prefab.GetComponent<Recycle>();
        // checks if prefab is recycles game object
        if (recycleScript != null)
        {
            // cretes reference to pool
            var pool = GetPool(recycleScript);
            // sets instance value to the polls next object
            instance = pool.Next(pos).gameObject;
        }
        // if it doesnt have a recycle script
        else
        {
            // sets instance to gameobject static method of the prefab
            instance = GameObject.Instantiate(prefab);
            // changes transform position 
            instance.transform.position = pos;
        }
        // returns instance
        return instance;

    }
    // destroy method 
    // passing in GameObject
    public static void Destroy(GameObject gameObject)
    {
        // stores recycled gameobject script
        var recycled = gameObject.GetComponent<Recycle>();

        // if checks if game object should be destroyed of recycled
        if (recycled != null)
        {
            //calls shutdown on gameobject
            recycled.ShutDown();
        }
        else
        {
            // using GomeObject.Destroy method to destroy gameObject
            GameObject.Destroy(gameObject);
        }
    }
    // returns instance of pool based on game object created
    // passes in reference 
    private static Pool GetPool(Recycle reference)
    {
        // creates reference of pool
        Pool pool = null;
        // checks if key exists in the dictonary using ContainsKey
        if(pools.ContainsKey (reference)){
            // sets pool value to equal reference
            // reference beeing the key
            pool = pools[reference];

        }
            // if pool not found
            // creates new pool
        else
        {
            // creates new gameObject
            // gives new gamobject a name
            var poolcontainer = new GameObject(reference.gameObject.name + "ObjectPool");
            // adds object pool script to new pool container
            pool = poolcontainer.AddComponent<Pool>();
            // pool prefab property
            pool.prefab = reference;
            // adds pools to dictionary
            pools.Add(reference, pool);
        }
        // returns pool
        return pool;
    }

}
