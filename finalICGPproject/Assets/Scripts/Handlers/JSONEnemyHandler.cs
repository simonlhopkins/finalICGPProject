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
            



            StartCoroutine(fetchImageFromURL(baseJSON.users.items[i].profile_image_url.Replace("_normal",""),
                                             baseJSON.users.items[i]));

        }
        
    }


    IEnumerator fetchImageFromURL(string url, TwitterUserType userInfo)
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            Texture2D tex = new Texture2D(4, 4, TextureFormat.ARGB32, false);
            www.LoadImageIntoTexture(tex);
            GameObject newEnemyGO = Instantiate(enemy);
            newEnemyGO.SetActive(false);

            //Texture2D scaledTexture = TextureScaler.scaled(tex, 100, 100);
            newEnemyGO.GetComponent<EnemyBaseClass>().Texture = tex;
            newEnemyGO.GetComponent<EnemyBaseClass>().setStringVariables(userInfo);
            allEnemies.Add(newEnemyGO);
        }
    }
}
