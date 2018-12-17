using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogHandler : MonoBehaviour {


    private RectTransform logContent;
    public GameObject logTextGO;
    // Use this for initialization
    void Start () {
		
	}


	
	// Update is called once per frame
	void Update ()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "startScene") {
            logContent = GameObject.FindWithTag("logContentRect").GetComponent<RectTransform>();
        }
    }

    public void writeToLog(string message, Color color) {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "startScene") {
            return;
        }
        print(message);
        GameObject newLogText = Instantiate(logTextGO, logContent.transform, false);
        newLogText.GetComponent<Text>().text = message;
        newLogText.GetComponent<Text>().color = color;


    }
}
