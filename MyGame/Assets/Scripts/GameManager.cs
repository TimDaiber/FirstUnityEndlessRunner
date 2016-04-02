using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class GameManager : MonoBehaviour {

    public GameObject playerPrefab;
    public Text continuedText;
    private bool gameS;

    public Text score;

    private float elapsed;
    private float best;

    private TimeManager timeManager;
    private bool blink;
    private float blinktime = 0f;
    private GameObject player;
    private GameObject floor;
    private Spawner spawner;

    private bool newbest;

    void Awake()
    {
        floor = GameObject.Find("Forground");
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();

        timeManager = GetComponent<TimeManager>();
    }


	// Use this for initialization
	void Start () {

        var floorh = floor.transform.localScale.y;

        var pos = floor.transform.position;
        pos.x = 0;
        pos.y = -((Screen.height / PixelPervectCamera.pixelToUnits) / 2) + (floorh / 2);
        floor.transform.position = pos;

        spawner.active = false;

        best = PlayerPrefs.GetFloat("BestTime");

        Time.timeScale = 0;

        continuedText.text = "Press Any Key to start";

        
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameS && Time.timeScale == 0)
        {
            if (Input.anyKeyDown)
            {
                timeManager.ManipulateTime(1, 1f);
                RestGame();
            }
        }

        if (!gameS)
        {
            blinktime++;
            if (blinktime % 40==0)
            {
                blink = !blink;
            }
            continuedText.canvasRenderer.SetAlpha(blink ? 0 : 1);

            var txtColor = newbest ? "#FF0" : "#FFF";

            score.text = "TIME: " +FTime(elapsed)+"\n<color="+txtColor+">BEST: "+FTime(best)+"</color>";
        }
        else
        {
            elapsed += Time.deltaTime;
            score.text = "TIME: " + FTime(elapsed);
        }

        if (spawner.active == false && Time.timeScale > 0 )
        {
            if(Input.anyKeyDown){
                timeManager.ManipulateTime(1, 1f);
                Killed();
                //Start();
            }

            //timeManager.ManipulateTime(0, 2.5f);
            //if (Input.anyKeyDown)
            //{

            //    RestGame();
            //}
        }
	}

    void Killed()
    {
        spawner.active = false;

        var playerDestroyScript = player.GetComponent<Destroy>();
        playerDestroyScript.DestryCallBack -= Killed;

        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        timeManager.ManipulateTime(0, 2.5f);
        gameS = false;

        if (elapsed > best)
        {
            best = elapsed;
            PlayerPrefs.SetFloat("BestTime", best);
            newbest = true;
        }

        continuedText.text = "ANY KEY TO RESTART";

       


        if (Input.anyKeyDown)
        {
            RestGame();
        }
    }
    void RestGame()
    {
        spawner.active = true;

        player = GameObjectUtil.Instantiate(playerPrefab, new Vector3(0, (Screen.height / PixelPervectCamera.pixelToUnits) / 2+100, 0));

        var playerDestroyScript = player.GetComponent<Destroy>();
        playerDestroyScript.DestryCallBack += Killed;
        gameS = true;
        continuedText.canvasRenderer.SetAlpha(0);

        elapsed = 0;
    }

    string FTime(float value)
    {
        TimeSpan t = TimeSpan.FromSeconds(value);

        return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }
}
