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
    public GameObject inputField;
	void Start () {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>().text;
        button.onClick.AddListener(onButtonClick);
        gameManager = GameObject.FindWithTag("gameManager");
        inputField = GameObject.FindWithTag("inputField");

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onButtonClick() {
        gameManager.GetComponent<TwitterManagerScript>().username = assocUserName;
        inputField.GetComponentInChildren<Text>().text = assocUserName;
        for(int i = 0; i<transform.parent.childCount; i++) {
            transform.parent.GetChild(i).GetComponent<Image>().color = Color.white;
        }
        GetComponent<Image>().color = Color.red;
        gameManager.GetComponent<LogHandler>().writeToLog(assocUserName + " selected", Color.green);
    }
}
