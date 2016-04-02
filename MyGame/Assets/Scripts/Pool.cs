using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Pool : MonoBehaviour {

    public Recycle prefab;

    private List<Recycle> poolinstance = new List<Recycle>();

    private Recycle Create(Vector3 pos)
    {
        var clone = GameObject.Instantiate(prefab);
        clone.transform.position = pos;
        clone.transform.parent = transform;

        poolinstance.Add(clone);
        return clone;
    }

    public Recycle Next(Vector3 pos)
    {
        Recycle instance = null;

        foreach (var go in poolinstance)
        {
            if (go.gameObject.activeSelf != true)
            {
                instance = go;
                instance.transform.position = pos;
            }
        }

        if (instance == null) { 
            instance = Create(pos);
        }
        
        instance.Restart ();
        return instance;
    }

}
