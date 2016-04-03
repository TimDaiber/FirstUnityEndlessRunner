using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// creates new interface
public interface IRecycle
{
    // interface has to contain these to methods
    void Restart();
    void ShutDown();
}



public class Recycle : MonoBehaviour {

    // creates list of all game object that implement IRecycle
    private List<IRecycle> recycleComponents;

    // awake happens as soon as the class starts up
    void Awake()
    {
        // gets all components the game object is attached to
        var components = GetComponents<MonoBehaviour>();
        // instantiate recycled components list
        recycleComponents = new List<IRecycle>();
        // loops over all components and checks if the component is IRecycle
        foreach(var component in components){
            if (component is IRecycle)
            {
                // if it is add it to the list
                recycleComponents.Add(component as IRecycle);
            }           
        }
        //Debug.Log(name + " Found " + recycleComponents.Count + " Components");
    }
    
    public void Restart()
    {
        // gets reference ofgameobject 
        // SetActive allows to mke a gameobject active or inactive
        gameObject.SetActive(true);
        // loops over all components in (recycled components)
        foreach (var component in recycleComponents)
        {
           // calls restart on the component
            component.Restart();
        }
    }


    // creates shutdown
    public void ShutDown()
    {
        // gets reference ofgameobject 
        // SetActive allows to mke a gameobject active or inactive
        gameObject.SetActive(false);
        // loops over the components (recycled components)
        foreach (var component in recycleComponents)
        {
            // calls shut down on component
            component.ShutDown();
        }
    }

}
