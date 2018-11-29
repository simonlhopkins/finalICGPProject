using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//This is the class for keeping the username, twitter data, and their last login
namespace JSONclasses
{


    [Serializable]

    public class FriendsIds
    {
        public List<string> ids;
        public int next_cursor;
        public string next_cursor_str;
        public int previous_cursor;
        public string previous_cursor_str;


    }
}