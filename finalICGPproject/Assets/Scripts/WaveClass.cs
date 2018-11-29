using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveClass : MonoBehaviour {


    private List<EnemyBaseClass> enemiesInWave;
    public List<EnemyBaseClass> EnemiesInWave{
        get
        {
            return enemiesInWave;
        }
        set
        {
            enemiesInWave = value;
        }
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

