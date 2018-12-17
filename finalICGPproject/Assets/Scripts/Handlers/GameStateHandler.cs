using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSONclasses;
using System;

public class GameStateHandler : MonoBehaviour {

    public KeyboardHandler kh;
    public GameObject currentEnemy;
    public LevelClass currentLevel;
    [SerializeField]
    public List<GameObject> currentWave;
    [SerializeField]
    public GameObject player;

    public static GameStateHandler i;

    void Awake()
    {
        if (!i)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Start () {
        print("start called in game state handler");
        kh = GetComponent<KeyboardHandler>();
        kh.TabPressed += OnTabPressed; //Register the OnTabPressed delegate to the event
    }
	
	// Update is called once per frame

	void Update () {


        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "startScene") {
            return;
        }
        if (Input.anyKeyDown) {
            UpdatePlayerTextState();
        }
    }

    public void OnTabPressed(object sender, EventArgs e)
    {
        print("Tab was registered in GameStateHandler");
    }

    private void UpdatePlayerTextState()
    {

        if (kh.CurrentLettersTyped.Length == 0) {
            return;
        }
        var enemyControl = currentEnemy.GetComponent<EnemyBaseClass>() as EnemyBaseClass;
        //TODO: May account for backspace. Check to be certain. 

        try
        {
            if (enemyControl.UpdateTextToKillTypedText(kh.CurrentLettersTyped))
            {
                player.GetComponent<Player>().streak += 1;
                if(enemyControl.TextToKill.ToLower().Equals(kh.CurrentLettersTyped.ToLower()))
                {
                    kh.ClearCurrentLettersTyped(); // clear letters typed if enemy is killed.
                }
            }
            else
            {
                player.GetComponent<Player>().streak = 1;
                kh.ClearCurrentLettersTyped(); //clear typed letters if it does not match the enemy text to kill
            }
        }
        catch (System.Exception e)
        {
            print(kh.CurrentLettersTyped);
            print("Error message: " + e.StackTrace);
            throw;
        }

        //print("UpdatePlayerTextState()");
    }
}
