using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour {

	// Use this for initialization
    private GameStateHandler gameStateHandler;
    public List<GameObject> allEnemies;

    public int numberOfEnemiesInWave = 5;

    void Start () {
        gameStateHandler = GetComponent<GameStateHandler>();
        // THIS SHOUDLD EVENTUALLY BE CALLED IN THE GAME STATE HANDLER SCRIPT EVERY TIME A NEW WAVE SHOULD BE SPAWNED

	}
	
	// Update is called once per frame
	void Update () {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "startScene") {
            return;
        }

        handleCurrentWaveSpawning(2f, 5f);

    }

    //this should do a lot of checking and adding new constraints and such
    public void spawnNewWave(){
        if (allEnemies.Count == 0) {

            return;
        }
        for (int i = 0; i < numberOfEnemiesInWave; i++)
        {

            if(allEnemies[i] == null) {
                print("reached a null part of the all enemies list");
                break;
            }
            allEnemies[i].hideFlags = 0;
            GetComponent<GameStateHandler>().currentWave.Add(allEnemies[i]);

            allEnemies.Remove(allEnemies[i]);
        }
        GetComponent<GameStateHandler>().currentEnemy = GetComponent<GameStateHandler>().currentWave[0];
    }

    private float elapsedTime = 0;
    private float timeToNextSpawn = 0;
    //this function assumes that there is always enemies in thescene
    public void handleCurrentWaveSpawning(float lowerBounds, float upperBounds) {
      
        if (elapsedTime >= timeToNextSpawn) {

            for(int i=0; i<gameStateHandler.currentWave.Count; i++)
            {

                if (!gameStateHandler.currentWave[i].activeInHierarchy) {
                    gameStateHandler.currentWave[i].SetActive(true);
                    gameStateHandler.currentWave[i].transform.position = new Vector3(Random.Range(-5f, 5f), 4f, 0f);
                    break;
                }
            }

            timeToNextSpawn = Random.Range(lowerBounds, upperBounds);
            elapsedTime = 0;
        }


        elapsedTime += Time.deltaTime;
    
    }

    public void resetCurrentEnemyOnKill(GameObject enemyDestroyed) {


        int indexOfDestroyedEnemy = gameStateHandler.currentWave.IndexOf(enemyDestroyed);
        gameStateHandler.player.GetComponent<Player>().streak = 0;
        gameStateHandler.currentWave.Remove(enemyDestroyed);
        Destroy(enemyDestroyed, 0.15f);
        //this was the last enemey in the current enemy wave, spawn a new wave
        if (gameStateHandler.currentWave.Count == 0)
        {
            timeToNextSpawn = 0;
            spawnNewWave();
            return;
        }


        gameStateHandler.currentEnemy = gameStateHandler.currentWave[indexOfDestroyedEnemy % gameStateHandler.currentWave.Count];

        //gameStateHandler.currentWave.Remove(enemyDestroyed);


    }
}
