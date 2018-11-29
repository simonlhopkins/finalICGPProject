using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class KeyboardHandler : MonoBehaviour {

    private StringBuilder currentLettersTyped;
    private char lastLetterTyped;

    public string CurrentLettersTyped
    {
        get
        {
            return CurrentLettersTyped.ToString();
        }
       
    }

    void ClearCurrentLettersTyped()
    {
        currentLettersTyped.Remove(0, currentLettersTyped.Length);
    }

    // Use this for initialization
    void Start () {
        currentLettersTyped = new StringBuilder(50);
	}
	
	// Update is called once per frame
	void Update () {
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
                    currentLettersTyped.Remove(_length - 1, 1);
                    _length = currentLettersTyped.Length;
                    lastLetterTyped = currentLettersTyped.ToString()[_length - 1];
                    break;
                case "\n": //return key
                    break;
                default:
                    currentLettersTyped.Append(_input);
                    lastLetterTyped = _input.ToCharArray()[0];
                    break;
            }
        }
    }
}
