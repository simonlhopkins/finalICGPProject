using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBaseClass : MonoBehaviour
{
using JSONclasses;

public class EnemyBaseClass : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    public string TextToKill { get; set; }

    [SerializeField]
    public Texture2D Texture { get; set; }

<<<<<<< HEAD
    [SerializeField]
    public Text TextOnScreen;

    void Start()
    {
=======
    public string name;
    public string screen_name;
    public string description;
    public string location;
    public int followers_count;
    public int friends_count;
    public int favourites_count;

	void Start () {
>>>>>>> afdfbf4d5959c30ed34adf58b88500fe6428b966
        resizeTextureOnLoad();


    }

    // Update is called once per frame
    void Update()
    {
        TextOnScreen.transform.position = this.transform.position + Vector3.up * 100;
    }


    void resizeTextureOnLoad()
    {
        print(Texture.width);
        TextureScale.Bilinear(Texture, 500, 500);
        Sprite newSprite = Sprite.Create(Texture, new Rect(0.0f, 0.0f, Texture.width, Texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void setStringVariables(TwitterUserType user){
        name = user.name;
        screen_name = user.screen_name;
        description = user.description;
        location = user.location;
        followers_count = user.followers_count;
        friends_count = user.friends_count;
        favourites_count = user.favourites_count;
    }
}
