using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonScript : MonoBehaviour {

    // Use this for initialization

    private Button playButton;
    private GameObject gameManager;

	void Start () {
        playButton = GetComponent<Button>();
        playButton.onClick.AddListener(onButtonClick);
        gameManager = GameObject.FindWithTag("gameManager");

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void onButtonClick() {
        string _userName = gameManager.GetComponent<TwitterManagerScript>().username;
        if (_userName != "") {
            gameManager.GetComponent<TwitterManagerScript>().onUserSelected(_userName);
        }

    }
}
