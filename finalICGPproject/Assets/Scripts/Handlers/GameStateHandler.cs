using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour {

    public KeyboardHandler kh;
    public GameObject currentEnemy;
    public LevelClass currentLevel;
    [SerializeField]
    public WaveClass currentWave;
    public GameObject player; 

    

	// Use this for initialization
	void Start () {
        kh = new KeyboardHandler();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
