using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace JSONclasses
{


    [Serializable]

    public class TwitterUserType
    {
        public long id;
        public string id_str;
        public string name;
        public string screen_name;
        public string location;
        public string description;
        public string url;
        public int followers_count;
        public int friends_count;
        public int listed_count;
        public string created_at;
        public int favourites_count;
        public bool verified;
        public int statuses_count;
        public string lang;
        //public StatusType status;
        public string profile_background_color;
        public string profile_background_image_url;
        public string profile_background_image_url_https;
        public string profile_image_url;
        public string profile_image_url_https;


    }
}