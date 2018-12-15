using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugGenerateEnemyData : MonoBehaviour {

    // Use this for initialization

    private GameObject gameManager;
	void Start () {
        gameManager = GameObject.Find("gameManager");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P)) {

            gameManager.GetComponent<TwitterManagerScript>().onUserSelected("slimon_slopkins");
            gameManager.GetComponent<GameStateHandler>().currentEnemy = gameManager.GetComponent<WaveHandler>().allEnemies[0]; 
            gameManager.GetComponent<GameStateHandler>().debugArrayPopulated = true;


        }

    }
}
