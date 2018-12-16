using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class KeyboardHandler : MonoBehaviour {

    private StringBuilder currentLettersTyped = new StringBuilder(128);
    private char lastLetterTyped;

    public event TabPressedEventHandler TabPressed;
    public delegate void TabPressedEventHandler(object sender, EventArgs e);

    protected virtual void OnTabPressed()
    {
        if(TabPressed != null)
        {
            TabPressed(this, EventArgs.Empty);
        }
    }

    public string LastLetterTyped
    {
        get
        {
            return lastLetterTyped.ToString();
        }
    }

    public string CurrentLettersTyped
    {
        get
        {
            return currentLettersTyped.ToString();
        }
    }

    public void ClearCurrentLettersTyped()
    {
        currentLettersTyped.Remove(0, currentLettersTyped.Length);
    }

    // Use this for initialization
    void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "startScene") {
            return;
        }
        UpdateCurrentLettersTyped();
    }

    private void UpdateCurrentLettersTyped()
    {
        if (Input.anyKeyDown)
        {

            string _input = Input.inputString;
            int _length = currentLettersTyped.Length;
            switch (_input)
            {
                case "\t":
                    OnTabPressed();
                    break;
                case "\b": //backspace
                    if (_length == 0) break;
                    currentLettersTyped.Remove(_length - 1, 1);
                    _length = currentLettersTyped.Length;
                    if (_length == 0) {
                        lastLetterTyped = ' ';
                    }
                    else {
                        lastLetterTyped = currentLettersTyped.ToString()[_length - 1];
                    }

                    print("CurrentLettersTyped: " + currentLettersTyped.ToString());
                    break;

                case "\n": //return key
                    break;

                case "":
                    break;

                default:
                    currentLettersTyped.Append(_input);
                    lastLetterTyped = _input.ToCharArray()[0];
                    print("CurrentLettersTyped: " + currentLettersTyped.ToString());
                    break;
            }

        }
    }
}
