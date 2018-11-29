using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//This is the class for keeping the username, twitter data, and their last login
namespace JSONclasses
{


    [Serializable]

    public class FriendUsers
    {
        public List<TwitterUserType> items;


    }
}