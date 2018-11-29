using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseClass : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private string textToKill;

    public string TextToKill{
        get
        {
            return textToKill;
        }
        set
        {
            textToKill = value;
        }
    }
    [SerializeField]
    private Texture2D texture;
    public Texture2D Texture
    {
        get
        {
            return texture;
        }
        set
        {
            texture = value;
        }
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
