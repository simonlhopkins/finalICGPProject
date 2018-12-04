using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour {

    KeyboardHandler kh;
    EnemyBaseClass currentEnemy;
    LevelClass currentLevel;
    WaveClass currentWave;
    Player player; 

	// Use this for initialization
	void Start () {
        kh = new KeyboardHandler();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
