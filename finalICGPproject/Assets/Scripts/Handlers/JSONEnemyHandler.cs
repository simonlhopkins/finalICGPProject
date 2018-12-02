using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSONclasses;

public class JSONEnemyHandler : MonoBehaviour {

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



            StartCoroutine(fetchImageFromURL(baseJSON.users.items[i].profile_image_url.Replace("_normal",""),
                                             baseJSON.users.items[i].screen_name));

        }
        
    }


    IEnumerator fetchImageFromURL(string url, string textToKill)
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            Texture2D tex = new Texture2D(4, 4, TextureFormat.ARGB32, false);
            www.LoadImageIntoTexture(tex);
            GameObject newEnemyGO = Instantiate(enemy);


            //Texture2D scaledTexture = TextureScaler.scaled(tex, 100, 100);
            newEnemyGO.GetComponent<EnemyBaseClass>().Texture = tex;
            newEnemyGO.GetComponent<EnemyBaseClass>().TextToKill = textToKill;

            allEnemies.Add(newEnemyGO);
        }
    }
}
