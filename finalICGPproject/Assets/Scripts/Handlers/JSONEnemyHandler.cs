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
            


            GameObject newEnemyGO = Instantiate(enemy);
            newEnemyGO.SetActive(false);
            StartCoroutine(fetchImageFromURL(baseJSON.users.items[i].profile_image_url.Replace("_normal",""),
                                             baseJSON.users.items[i], newEnemyGO));
            allEnemies.Add(newEnemyGO);

        }

        print(allEnemies.Count);
        
    }


    IEnumerator fetchImageFromURL(string url, TwitterUserType userInfo, GameObject targetEnemy)
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            Texture2D tex = new Texture2D(4, 4, TextureFormat.ARGB32, false);
            www.LoadImageIntoTexture(tex);


            //Texture2D scaledTexture = TextureScaler.scaled(tex, 100, 100);
            targetEnemy.GetComponent<EnemyBaseClass>().Texture = tex;
            targetEnemy.GetComponent<EnemyBaseClass>().setStringVariables(userInfo);

        }
    }
}
