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
}
