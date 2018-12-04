﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JSONclasses;

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

    public string name;
    public string screen_name;
    public string description;
    public string location;
    public int followers_count;
    public int friends_count;
    public int favourites_count;

	void Start () {
        resizeTextureOnLoad();

	}
	
	// Update is called once per frame
	void Update () {
        
		
	}


    void resizeTextureOnLoad(){
        print(texture.width);
        TextureScale.Bilinear(texture, 500, 500);
        Sprite newSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void setStringVariables(TwitterUserType user){
        name = user.name;
        screen_name = user.screen_name;
        description = user.description;
        location = user.location;
        followers_count = user.followers_count;
        friends_count = user.friends_count;
        favourites_count = user.favourites_count;
    }
}
