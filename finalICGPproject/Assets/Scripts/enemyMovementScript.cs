using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementScript : MonoBehaviour {

    private GameObject player;
    public float movementSpeedMod = 1f;

   	// Use this for initialization
	void Start () {
        player = GameObject.Find("gameManager").GetComponent<GameStateHandler>().player;
	}
	
	// Update is called once per frame
	void Update () {
        movement();
	}


    void movement() {

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime / movementSpeedMod);

    }
}
