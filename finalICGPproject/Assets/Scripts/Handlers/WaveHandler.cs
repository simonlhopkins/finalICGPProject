using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour {

	// Use this for initialization
    private GameStateHandler gameStateHandler;
	void Start () {
        gameStateHandler = GetComponent<GameStateHandler>();
        //THIS SHOUDLD EVENTUALLY BE CALLED IN THE GAME STATE HANDLER SCRIPT
        spawnNewWave();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void spawnNewWave(){
        for (int i = 0; i < 10; i++){
            print(gameStateHandler.GetComponent<JSONEnemyHandler>().allEnemies[i].name);
        }

    }
}
