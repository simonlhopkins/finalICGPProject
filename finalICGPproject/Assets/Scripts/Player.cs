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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clearContent() {
        health = 0;
        gameUserJSON = null;
        followerCount = 0;
        userName = "";
}
}
