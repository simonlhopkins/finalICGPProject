using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health;
    public readonly SpriteRenderer playerPhoto;

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
}
