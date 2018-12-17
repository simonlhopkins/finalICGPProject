using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementScript : MonoBehaviour {

    private GameObject player;
    private GameObject gameManager;
    public float playerStreakSpeedMod = 1f;
    public float baseSpeed;
    public EnemyBaseClass enemyBaseClass;

   	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("gameManager");
        player = GameObject.Find("gameManager").GetComponent<GameStateHandler>().player;
        enemyBaseClass = GetComponent<EnemyBaseClass>();
        baseSpeed = 3f;

    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject == gameManager.GetComponent<GameStateHandler>().currentEnemy) {
            //change player 
            playerStreakSpeedMod = player.GetComponent<Player>().streak;
            //esure you never get a divide by 0
            playerStreakSpeedMod = baseSpeed - Mathf.Clamp(0.1f * playerStreakSpeedMod, 0, baseSpeed);
        }

        movement();
	}


    void movement() {

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, playerStreakSpeedMod * Time.deltaTime);

    }
}
