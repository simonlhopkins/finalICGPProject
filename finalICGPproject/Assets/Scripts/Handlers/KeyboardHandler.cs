using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class KeyboardHandler : MonoBehaviour {

    private StringBuilder currentLettersTyped = new StringBuilder(128);
    private char lastLetterTyped;

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
                case "\b": //backspace
                    if (_length == 0) break;
                    currentLettersTyped.Remove(_length - 1, 1);
                    _length = currentLettersTyped.Length;
                    lastLetterTyped = currentLettersTyped.ToString()[_length - 1];
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
