using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour {

	// Use this for initialization
    private GameStateHandler gameStateHandler;
    public GameObject jSONEnemyHandler;
	void Start () {
        gameStateHandler = GetComponent<GameStateHandler>();
        //THIS SHOUDLD EVENTUALLY BE CALLED IN THE GAME STATE HANDLER SCRIPT EVERY TIME A NEW WAVE SHOULD BE SPAWNED

	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space)){
            spawnNewWave();
        }
	}

    void spawnNewWave(){
        
        WaveClass newWave = new WaveClass();
        newWave.EnemiesInWave = new List<GameObject>();
        for (int i = 0; i < 10; i++){
            newWave.EnemiesInWave.Add(jSONEnemyHandler.GetComponent<JSONEnemyHandler>().allEnemies[i]);
        }

        //gameStateHandler.
        //newWave.EnemiesInWave 

        
    }
}
