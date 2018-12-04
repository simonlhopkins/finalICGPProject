using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBaseClass : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    public string TextToKill { get; set; }

    [SerializeField]
    public Texture2D Texture { get; set; }

    [SerializeField]
    public Text TextOnScreen;

    void Start()
    {
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
}
