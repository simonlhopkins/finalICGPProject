using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSONclasses;


public class JSONEnemyHelper : MonoBehaviour {

    // Use this for initialization

    public List<GameObject> allEnemies;
    public GameObject enemy;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void loadJSONDataToEnemies(GameUserJSON baseJSON){
        
        for (int i = 0; i < baseJSON.users.items.Count; i++){
            
            //start a coroutine to load in the image as a texture from the WWW file
            //make a base texture that gets set to the new enemy


            //instantiate enemy



            StartCoroutine(fetchImageFromURL(baseJSON.users.items[i].profile_image_url,
                                             baseJSON.users.items[i].screen_name));

        }
        
    }


    IEnumerator fetchImageFromURL(string url, string textToKill)
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            Texture2D tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
            www.LoadImageIntoTexture(tex);
            GameObject newEnemyGO = Instantiate(enemy);
            newEnemyGO.GetComponent<EnemyBaseClass>().Texture = tex;
            newEnemyGO.GetComponent<EnemyBaseClass>().TextToKill = textToKill;

            Sprite newSprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            newEnemyGO.GetComponent<SpriteRenderer>().sprite = newSprite;
            allEnemies.Add(newEnemyGO);
        }
    }
}
