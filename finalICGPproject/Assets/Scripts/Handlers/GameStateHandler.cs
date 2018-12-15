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
        if(Input.anyKeyDown)
        {
            UpdatePlayerTextState();
        }
	}

    private void UpdatePlayerTextState()
    {
        var enemyControl = currentEnemy.GetComponent<EnemyBaseClass>() as EnemyBaseClass;
        //TODO: May account for backspace. Check to be certain. 
        try
        {
            if (enemyControl.UpdateTextToKillTypedText(kh.CurrentLettersTyped))
            {

            }
            else
            {
                kh.ClearCurrentLettersTyped(); //clear typed letters if it does not match the enemy text to kill
            }
        }
        catch (System.Exception e)
        {
            print("Error message: " + e.StackTrace);
        }

        //print("UpdatePlayerTextState()");
    }
}
