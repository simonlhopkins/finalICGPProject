using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogHandler : MonoBehaviour {


    public RectTransform logContent;
    public GameObject logTextGO;
    // Use this for initialization
    void Start () {
		
	}


	
	// Update is called once per frame
	void Update ()
    {
       
    }

    public void writeToLog(string message, Color color) {
        print(message);
        GameObject newLogText = Instantiate(logTextGO, logContent.transform, false);
        newLogText.GetComponent<Text>().text = message;
        newLogText.GetComponent<Text>().color = color;


    }
}
