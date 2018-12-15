using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewUserInputScript : MonoBehaviour {

    // Use this for initialization

    private InputField inputField;
    private GameObject gameManager;

	void Start () {
        inputField = GetComponent<InputField>();
        InputField.SubmitEvent submitEvent = new InputField.SubmitEvent();
        submitEvent.AddListener(onEndInput);
        inputField.onEndEdit = submitEvent;
        gameManager = GameObject.FindWithTag("gameManager");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void onEndInput(string input) {
        print(input);
        gameManager.GetComponent<TwitterManagerScript>().username = input;
    }
}
