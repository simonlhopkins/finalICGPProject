using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveClass {


    [SerializeField]
    public List<GameObject> EnemiesInWave{get; set;}

    public Difficulty difficulty;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

