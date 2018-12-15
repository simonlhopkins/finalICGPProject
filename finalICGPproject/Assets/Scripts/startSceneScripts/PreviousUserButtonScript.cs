using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviousUserButtonScript : MonoBehaviour {

    // Use this for initialization

    private Button button;
    private string buttonText;
    public string assocUserName;
    private GameObject gameManager;
	void Start () {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>().text;
        button.onClick.AddListener(onButtonClick);
        gameManager = GameObject.FindWithTag("gameManager");
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onButtonClick() {
        gameManager.GetComponent<TwitterManagerScript>().username = assocUserName;
    }
}
