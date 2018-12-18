using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemiesKilledUI : MonoBehaviour {

    GameObject gm;
    Text uiText;
    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindWithTag("gameManager");
        uiText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = "Enemies Killed: " + gm.GetComponent<GameStateHandler>().score.ToString();
    }
}
