using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLivesUI : MonoBehaviour {

    // Use this for initialization
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
        uiText.text = "Lives: " + gm.GetComponent<GameStateHandler>().player.GetComponent<Player>().GetHealth();
    }
}
