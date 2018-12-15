using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSONclasses;

public class JSONEnemyHandler : MonoBehaviour {

    // Use this for initialization

    public GameObject enemy;
    public GameObject gameManager;
    public int imagesLoaded = 0;


    void Start () {
        gameManager = GameObject.FindWithTag("gameManager");
    }

    // Update is called once per frame
    void Update () {
        if (gameManager.GetComponent<GameStateHandler>().player.followerCount ==  0)
        {
            return;
        }
        if (gameManager.GetComponent<TwitterManagerScript>().currentGameUserJSON.ids.ids.Count == imagesLoaded)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("simonTestScene");
        }
    }


    public void loadJSONDataToEnemies(GameUserJSON baseJSON){
        print("loading in enemies to array...");
        
        for (int i = 0; i < baseJSON.ids.ids.Count; i++){

            GameObject newEnemyGO = Instantiate(enemy);
            newEnemyGO.SetActive(false);
            newEnemyGO.hideFlags = HideFlags.HideInHierarchy;
            StartCoroutine(fetchImageFromURL(baseJSON.users.items[i].profile_image_url.Replace("_normal",""),
                                             baseJSON.users.items[i], newEnemyGO));
            gameManager.GetComponent<WaveHandler>().allEnemies.Add(newEnemyGO);



        }



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
            targetEnemy.transform.SetParent(gameManager.transform);
            imagesLoaded += 1;
            gameManager.GetComponent<LogHandler>().writeToLog("loading in image: " + imagesLoaded, Color.green);
        }
    }
   
}
