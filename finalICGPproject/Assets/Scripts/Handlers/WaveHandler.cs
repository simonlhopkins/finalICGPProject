using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour {

	// Use this for initialization
    private GameStateHandler gameStateHandler;
    public List<GameObject> allEnemies;
   
    public static WaveHandler i;


    void Start () {
        gameStateHandler = GetComponent<GameStateHandler>();
        //THIS SHOUDLD EVENTUALLY BE CALLED IN THE GAME STATE HANDLER SCRIPT EVERY TIME A NEW WAVE SHOULD BE SPAWNED

	}
	
	// Update is called once per frame
	void Update () {

	}

    void spawnNewWave(){
        
       

        
    }
}
