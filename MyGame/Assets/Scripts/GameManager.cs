using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class GameManager : MonoBehaviour {
    private GameObject player;
    // getting public properties 
    private GameObject floor;
    private Spawner spawner;
    public GameObject playerPrefab;
    // creating bool variables
    private bool blink;
    private bool newbest;
    private bool gameS;
    // creating text reference variables
    public Text continuedText;
    public Text score;
    // creating float variables
    private float blinktime = 0f;
    private float elapsed;
    private float best;
    // creating TimeManger reference variable
    private TimeManager timeManager; // not in use
    
    void Awake()
    {
        // getting gameObjects using Find
        floor = GameObject.Find("Forground");
        // also getting spawner reference
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        // not in use gets reference of TimManager Component
        timeManager = GetComponent<TimeManager>();
    }


	// Use this for initialization
	void Start () {
        // getting height of the floor game object
        var floorh = floor.transform.localScale.y;
        // creating position vector
        var pos = floor.transform.position;
        // center floor
        pos.x = 0;
        // calculate wher the bottom of the screen is
        pos.y = -((Screen.height / PixelPervectCamera.pixelToUnits) / 2) + (floorh / 2);
        // set floor position to current transform position
        floor.transform.position = pos;
        // setts spawner to inactive
        spawner.active = false;
        // gets BestTime stored in PlayerPrefs
        best = PlayerPrefs.GetFloat("BestTime");
        // setting timescale to 0
        Time.timeScale = 0;
        // setting continued text to message
        continuedText.text = "Press Any Key to start";

        
	}
	
	// Update is called once per frame
	void Update () {
        ////////////////// Not in use ///////////////////////////
        if (!gameS && Time.timeScale == 0)
        {
            if (Input.anyKeyDown)
            {
                timeManager.ManipulateTime(1, 1f);
                RestGame();
            }
        }
        /////////////////////////////////////////////////////////

        // if gameS false
        if (!gameS)
        {
            // adds one to blinktime
            blinktime++;
            // if blinktime 
            if (blinktime % 40==0)
            {
                blink = !blink;
            }
            continuedText.canvasRenderer.SetAlpha(blink ? 0 : 1);
            // creating new color
            var txtColor = newbest ? "#FF0" : "#FFF";
            // setting score.text (label in canvas) to elapsed time 
            // \n is for new line and new colour
            score.text = "TIME: " +FTime(elapsed)+"\n<color="+txtColor+">BEST: "+FTime(best)+"</color>";
        }
        else
        {
            elapsed += Time.deltaTime;
            score.text = "TIME: " + FTime(elapsed);
        }
        // if spawner is inactive and timescale is greater then 0
        if (spawner.active == false && Time.timeScale > 0 )
        {
            // if any key is pressed
            if(Input.anyKeyDown){
                // not in use
                // suppoused to slow down the game
                timeManager.ManipulateTime(1, 1f);
                // calls the player killed method
                Killed();
                //Start();
            }
            ///////////////////   not in use  /////////////////
            //timeManager.ManipulateTime(0, 2.5f);
            //if (Input.anyKeyDown)
            //{

            //    RestGame();
            //}
            ///////////////////////////////////////////////////
        }
	}

    void Killed()
    {
        // sets spawner inactive
        spawner.active = false;
        //creating reference to destroy scrip
        //getting reference  to destroycallback
        // tells destroy that when OnDestroyCallBack is called to call Killed in GameManager
        var playerDestroyScript = player.GetComponent<Destroy>();
        playerDestroyScript.DestryCallBack -= Killed;
        // setting player to 0 velosity so he can restart from the top of the screen again
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        // not in use // 
        // suppoused to slow down time 
        // making the game seem to slow time and pause
        timeManager.ManipulateTime(0, 2.5f);
        gameS = false;
        // if elapsed is greater then best
        if (elapsed > best)
        {
            // sets best time to elapsed time
            best = elapsed;
            // stores best time in PlayerPrefs under BestTime
            PlayerPrefs.SetFloat("BestTime", best);
            // sets newbest to true
            newbest = true;
        }
        // sets continued text to new message
        continuedText.text = "ANY KEY FOR MAIN MENU";

        // if any key is pressed
        if (Input.anyKeyDown)
        {
            // call restart method
            RestGame();
            //changescene(name);
        }
    }
    void RestGame()
    {
        // sets spawner to active
        spawner.active = true;
        // creates an instance of the player prefab
        // calculates the position of wher the player appears
        player = GameObjectUtil.Instantiate(playerPrefab, new Vector3(0, (Screen.height / PixelPervectCamera.pixelToUnits) / 2+100, 0));
        
         
        //creating reference to destroy scrip
        var playerDestroyScript = player.GetComponent<Destroy>();
        //getting reference  to destroycallback
        // tells destroy that when OnDestroyCallBack is called to call Killed in GameManager
        playerDestroyScript.DestryCallBack += Killed;
        // set bool to true
        gameS = true;
        // setting continued text to 0
        continuedText.canvasRenderer.SetAlpha(0);
        // set elapsed time to 0
        elapsed = 0;
    }
    // creating new method
    // passing in on vlaue
    string FTime(float value)
    {
        // creating TimeSpan t and setting it to vlaue
        TimeSpan t = TimeSpan.FromSeconds(value);
        // returning a string in a time format 00:00
        return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }
    public void changescene(string name)
    {
        
             Application.LoadLevel("MainMenu");
     
        //name = "MainMenu";
        //Application.LoadLevel(name);
    }
}
