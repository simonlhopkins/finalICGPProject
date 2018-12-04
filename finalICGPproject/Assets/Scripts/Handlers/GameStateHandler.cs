using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour {

    public KeyboardHandler kh;
    public EnemyBaseClass currentEnemy;
    public LevelClass currentLevel;
    public WaveClass currentWave;
    public Player player; 

    

	// Use this for initialization
	void Start () {
        kh = new KeyboardHandler();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
