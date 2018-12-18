using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementScript : MonoBehaviour {

    private GameObject player;
    private GameObject gameManager;
    public float playerStreakSpeedMod = 1f;
    public float baseSpeed;
    public float actualSpeed;
    public EnemyBaseClass enemyBaseClass;

   	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("gameManager");
        player = GameObject.Find("gameManager").GetComponent<GameStateHandler>().player;
        enemyBaseClass = GetComponent<EnemyBaseClass>();
        baseSpeed = 0.8f;
        actualSpeed = baseSpeed;

    }
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject == gameManager.GetComponent<GameStateHandler>().currentEnemy) {
            //change player 
            playerStreakSpeedMod = player.GetComponent<Player>().streak;
            //esure you never get a divide by 0
            actualSpeed = baseSpeed - Mathf.Clamp(0.03f * (playerStreakSpeedMod-1), 0, baseSpeed);
        }
        else {
            actualSpeed = baseSpeed;
        }

        movement();

	}


    void movement() {

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, actualSpeed * Time.deltaTime);
        if(gameManager.GetComponent<GameStateHandler>().currentEnemy== this.gameObject)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1.0f);
        }
        else {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
        }
    }
}
