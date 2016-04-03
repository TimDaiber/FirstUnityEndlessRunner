using UnityEngine;
using System.Collections;

// hole class not in use
public class TimeManager : MonoBehaviour {

    // create new method 2 arguments passed into the method
	    public void ManipulateTime(float newTime, float duration)
    {
            // if time > 0
        if (Time.timeScale == 0)
        {
            // set timeScale to .1f
            Time.timeScale = 0.1f;
            // starting corouting
            // calls corouting 
            // passes in 2 vales
            StartCoroutine( FadeTo  (newTime , duration ));
        }
    }

    // 
        IEnumerator FadeTo(float value, float time){
            // for loap 
            // loaps over the value of time
            // t represents base time
            // increments time by deltaTime
            //(increments based on difference of time between frames)
            for(float t = 0f ; t < 1 ; t += Time.deltaTime / time){
                // calculates the timescale of the current iteration of the loop
                // Lerp allows to alter a value from a start position to an end position 
                // over a sertain period of time
                Time.timeScale = Mathf.Lerp(Time.timeScale , value , t);
                // if absolute value of value - timscale <0.01f
                if (Mathf.Abs(value - Time.timeScale) < .01f)
                {
                    // set timeScale to value
                    Time.timeScale = value;
                    // returns fals
                    // not working correctly
                      yield return null;
                }
                // returns false
                yield return null;

            }
        
    }
}

