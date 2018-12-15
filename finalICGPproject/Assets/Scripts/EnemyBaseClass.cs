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
        if (typedText.Length == 0) return false; // probably not needed?

        if (textToKill.StartsWith(typedText, false, null))
        {
            textToKill_Typed = typedText; //TODO: Out of bounds exception below?
            textToKill_NotTyped = textToKill.Substring(typedText.Length - 1);
            return true;
        }

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
        texture = Texture2D.blackTexture;
        resizeTextureOnLoad();

        textToKill_NotTyped = textToKill;
        print("Start() has run...");
        print("TextOnScreen = " + TextOnScreen.text);





    }

	
	// Update is called once per frame
	void Update() 
    {

        TextOnScreen.transform.position = this.transform.position + Vector3.up * 35;
        TextOnScreen.text = StyleText(textToKill_Typed, textToKill_NotTyped);
	}


    /// <summary>
    /// Updates the text to kill to show progress on screen. Does not take backspace into account. 
    /// </summary>
    /// <returns><c>true</c>, if the char typed was next in <c>textToKill_NotTyped</c>, <c>false</c> otherwise.</returns>
    /// <param name="c">C.</param>
    public bool UpdateTextToKillAsTyped(string c)
    {
        if (textToKill_NotTyped.StartsWith(c, false, null)) //compare text case-insensitive
        {
            textToKill_Typed += textToKill_NotTyped.Remove(0);
            //textToKill = StyleText(textToKill_Typed, textToKill_NotTyped);
            return true;
        }
        return false;
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
        TextureScale.Bilinear(texture, 500, 500);
        Sprite newSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    #endregion
}



