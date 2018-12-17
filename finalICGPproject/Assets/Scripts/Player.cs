using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSONclasses;

[System.Serializable]
public class Player : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    public readonly SpriteRenderer playerPhoto;
    public GameUserJSON gameUserJSON;
    [SerializeField]
    public int followerCount;
    public string userName;

    public float playerY;

    public int streak;

    private GameObject gm;



    private float amplitude = 8.0f;
    public float frequency = 0.5f;
    private float _frequency;
    private float phase = 0.0f;
    private Transform trans;

    public static Player p;

    void Awake()
    {
        if (!p)
        {
            p = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public int DealDamage(int damage)
    {
        return (health = health - damage);
    }

    public int GetHealth()
    {
        return health;
    }

    // Use this for initialization
    void Start()
    {
        playerY = -3.5f;
        streak = 1;
        _frequency = frequency;
        trans = transform;
        gm = GameObject.FindWithTag("gameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "startScene") {

            return;
        }
        movement();
    }

    void movement() {

        transform.position = new Vector3(amplitude * Mathf.Sin(Time.time), playerY, 0f);
    }



   
    public void clearContent() {
        health = 3;
        gameUserJSON = null;
        followerCount = 0;
        userName = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag != "enemy")
        {
            return;
        }
        gm.GetComponent<WaveHandler>().resetCurrentEnemyOnKill(collision.gameObject);
        health -= 1;
        if (health <= 0) {


            for(int i =0; i< gm.GetComponent<WaveHandler>().allEnemies.Count; i++) {
                Destroy(gm.GetComponent<WaveHandler>().allEnemies[i]);
            }
            for (int i = 0; i < gm.GetComponent<GameStateHandler>().currentWave.Count; i++)
            {
                Destroy(gm.GetComponent<GameStateHandler>().currentWave[i]);
            }
            gm.GetComponent<WaveHandler>().allEnemies.Clear();
            gm.GetComponent<GameStateHandler>().currentWave.Clear();
            gm.GetComponent<TwitterManagerScript>().currentGameUserJSON = null;
            gameUserJSON = null;
            followerCount = 0;


            Invoke("switchSceneToStart", 0.5f);

        }

    }

    void switchSceneToStart() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("startScene");
    }
}
