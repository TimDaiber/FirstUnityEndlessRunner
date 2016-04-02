using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectUtil : MonoBehaviour {

    private static Dictionary<Recycle, Pool> pools = new Dictionary<Recycle, Pool>();




    public static GameObject Instantiate(GameObject prefab, Vector3 pos)
    {
        GameObject instance = null;

        var recycleScript = prefab.GetComponent<Recycle>();
        if (recycleScript != null)
        {
            var pool = GetPool(recycleScript);
            instance = pool.Next(pos).gameObject;
        }
        else
        {




            instance = GameObject.Instantiate(prefab);
            instance.transform.position = pos;
        }
        return instance;

    }

    public static void Destroy(GameObject gameObject)
    {

        var recycled = gameObject.GetComponent<Recycle>();


        if (recycled != null)
        {
            recycled.ShutDown();
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }

    private static Pool GetPool(Recycle reference)
    {
        Pool pool = null;

        if(pools.ContainsKey (reference)){
            pool = pools[reference];

        }
        else
        {
            var poolcontainer = new GameObject(reference.gameObject.name + "ObjectPool");
            pool = poolcontainer.AddComponent<Pool>();
            pool.prefab = reference;
            pools.Add(reference, pool);
        }
        return pool;
    }

}
