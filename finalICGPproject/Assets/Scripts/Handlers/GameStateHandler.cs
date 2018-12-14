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

    private void UpdatePlayerTextState()
    {
        var enemy = currentEnemy.GetComponent<EnemyBaseClass>() as EnemyBaseClass;
        if(Input.anyKeyDown)
        {
            //TODO: does not account for backspace. Will just try to add the previous letter again
            if(!enemy.UpdateTextToKillTypedText(kh.CurrentLettersTyped))
            {
                kh.ClearCurrentLettersTyped(); //clear typed letters if it does not match the enemy text to kill
            }
        }
    }
}
