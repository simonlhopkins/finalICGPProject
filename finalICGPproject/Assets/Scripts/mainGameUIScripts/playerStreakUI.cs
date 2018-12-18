using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStreakUI : MonoBehaviour {

    GameObject player;
    Text uiText;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        uiText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        uiText.text = "Streak: " + player.GetComponent<Player>().streak.ToString();
	}
}
