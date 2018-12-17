using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JSONclasses;

[System.Serializable]
public class EnemyBaseClass : MonoBehaviour {

    #region Public fields

    public string username;
    public string screen_name;
    public string description;
    public string location;
    public int followers_count;
    public int friends_count;
    public int favourites_count;
    public bool IsFocused { get; set; }
    

    #endregion

    #region Public components

    public Text TextOnScreen;

    #endregion

    #region Private fields

    private string textToKill_Typed = "";
    private string textToKill_NotTyped = "";

    #endregion

    

    [SerializeField]
    private string textToKill;
    public string TextToKill{
        get
        {
            return textToKill;
        }
        set
        {
            textToKill = value;
        }
    }

    /// <summary>
    /// Updates the <c>textToKill_Typed</c> and <c>textToKill_NotTyped</c>
    /// according to the the <c>typedText</c> 
    /// </summary>
    /// <param name="typedText">The typed text that needs to be checked against the <c>textToKill</c></param>
    /// <returns></returns>
    public bool UpdateTextToKillTypedText(string typedText)
    {
        //if (typedText.Length == 0) return false; // probably not needed?

        if (textToKill.StartsWith(typedText, true, null))
        {
            textToKill_Typed = typedText; //TODO: Out of bounds exception below?
            textToKill_NotTyped = textToKill.Substring(typedText.Length);
            if (isDead())
            {
                print("enemy dead");
                // play animation
                var _animator = GetComponentInChildren<Animator>();
                _animator.SetTrigger("DoTextCorrectAnimation");
                GameObject.Find("gameManager").GetComponent<WaveHandler>().resetCurrentEnemy(gameObject);

                Destroy(gameObject, 0.15f);
            }
            return true;
        }

        var animator = GetComponentInChildren<Animator>();
        animator.SetTrigger("DoTextWrongAnimation");
        textToKill_Typed = "";
        textToKill_NotTyped = textToKill;
        return false;
    }

    [SerializeField]
    private Texture2D texture;
    public Texture2D Texture
    {
        get
        {
            return texture;
        }
        set
        {
            texture = value;
        }
    }

    //Initialization
    void Start()
    {
        if(texture == null) {
            texture = Texture2D.blackTexture;
            texture.Resize(200, 200);
        }


        textToKill = username;
        TextOnScreen = GetComponentInChildren<Canvas>().GetComponentInChildren<Text>();
        textToKill_NotTyped = textToKill;
        resizeTextureOnLoad();

        print("Start() has run...");
        print("TextOnScreen = " + TextOnScreen.text);
    }

	
	// Update is called once per frame
	void Update() 
    {


        TextOnScreen.text = StyleText(textToKill_Typed, textToKill_NotTyped);
	}


   

    /// <summary>
    /// Deletes the last typed char.
    /// </summary>
    /// <returns>The last typed char.</returns>
    public string DeleteLastTypedChar()
    {
        int _length = textToKill_Typed.Length;
        string s = textToKill_Typed.Remove(_length - 1);
        textToKill_NotTyped = s + textToKill_NotTyped;
        return s;
    }

    /// <summary>
    /// Sets the string variables.
    /// </summary>
    /// <param name="user">User.</param>
    public void setStringVariables(TwitterUserType user){
        username = user.name;
        screen_name = user.screen_name;
        description = user.description;
        location = user.location;
        followers_count = user.followers_count;
        friends_count = user.friends_count;
        favourites_count = user.favourites_count;
    }

    #region Private methods

    /// <summary>
    /// Styles the text.
    /// </summary>
    /// <returns>The text.</returns>
    /// <param name="typed">Typed.</param>
    /// <param name="notTyped">Not typed.</param>
    private string StyleText(string typed, string notTyped)
    {
        return "<color=green><b>" + typed + "</b></color><color=red>" + notTyped + "</color>";
    }

    /// <summary>
    /// Deletes all typed text.
    /// </summary>
    private void deleteAllTypedText()
    {
        textToKill_NotTyped = textToKill_Typed + textToKill_NotTyped;
        textToKill_Typed = "";
    }

    /// <summary>
    /// Resizes the texture on load.
    /// </summary>
    private void resizeTextureOnLoad()
    {

        TextureScale.Bilinear(texture, 200, 200);
        Sprite newSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        GetComponentInChildren<SpriteRenderer>().sprite = newSprite;
        TextOnScreen.rectTransform.localPosition = new Vector3(0, -30, 0);

    }

    public bool isDead()
    {
        return textToKill.ToLower().Equals(textToKill_Typed.ToLower());
    }

    #endregion
}



