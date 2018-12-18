using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSONclasses;
using System.Linq;

public class JSONEnemyHandler : MonoBehaviour {

    // Use this for initialization

    public GameObject enemy;
    //public GameObject gameManager;
    public int imagesLoaded = 0;


    public static JSONEnemyHandler j;

    void Awake()
    {
        if (!j)
        {
            j = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }




    void Start () {
        //gameManager = GameObject.FindWithTag("gameManager");

    }

    // Update is called once per frame



    void Update () {
        if (GetComponent<GameStateHandler>().player.GetComponent<Player>().followerCount == 0)
        {
            return;
        }

    }

    void loadMainLevel() {

        if (GetComponent<GameStateHandler>().player.GetComponent<Player>().followerCount < 5) {
            GetComponent<LogHandler>().writeToLog("Please pick a user following more than 5 people", Color.red);
        }

        //make the fist wave of enemies
        //this should be its own method in game wave handler
        GetComponent<WaveHandler>().spawnNewWave();


        GetComponent<GameStateHandler>().currentEnemy = GetComponent<GameStateHandler>().currentWave[0];
        GetComponent<GameStateHandler>().player.SetActive(true);
        UnityEngine.SceneManagement.SceneManager.LoadScene("simonTestScene");
    }


    public void loadJSONDataToEnemies(GameUserJSON baseJSON){


        for (int i = 0; i < baseJSON.ids.ids.Count; i++){
        
            GameObject newEnemyGO = Instantiate(enemy);
            newEnemyGO.transform.position = new Vector3(0, 0, 0);
            newEnemyGO.SetActive(false);
            newEnemyGO.hideFlags = HideFlags.HideInHierarchy;
            StartCoroutine(fetchImageFromURL(baseJSON.users.items[i].profile_image_url.Replace("_normal",""),
                                             baseJSON.users.items[i], newEnemyGO));
            GetComponent<WaveHandler>().allEnemies.Add(newEnemyGO);
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
            targetEnemy.transform.SetParent(transform);
            imagesLoaded += 1;
            print("follower count: " + GetComponent<GameStateHandler>().player.GetComponent<Player>().followerCount);
            if (GetComponent<GameStateHandler>().player.GetComponent<Player>().followerCount == imagesLoaded)
            {
                imagesLoaded = 0;
                GetComponent<WaveHandler>().allEnemies.Sort(CompareScreenName);
                loadMainLevel();
            }
        }
    }
    private int CompareScreenName(GameObject a, GameObject b)
    {
        float distance_a = a.GetComponent<EnemyBaseClass>().screen_name.Length;
        float distance_b = b.GetComponent<EnemyBaseClass>().screen_name.Length;
        if (distance_a >= distance_b)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
