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



    private float amplitude = 8.0f;
    public float frequency = 0.5f;
    private float _frequency;
    private float phase = 0.0f;
    private Transform trans;

    public static Player i;

    void Awake()
    {
        if (!i)
        {
            i = this;
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
    }

    // Update is called once per frame
    void Update()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "startScene") {
            gameObject.SetActive(false);
            return;
        }

        movement();
    }

    void movement() {

        transform.position = new Vector3(amplitude * Mathf.Sin(Time.time), playerY, 0f);
    }



   
    public void clearContent() {
        health = 0;
        gameUserJSON = null;
        followerCount = 0;
        userName = "";
    }
}
