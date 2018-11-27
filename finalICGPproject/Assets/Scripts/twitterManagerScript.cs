
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Twity.DataModels.Responses;
using Twity.DataModels.Core;
using UnityEngine.UI;
using System.IO;
using JSONclasses;
using UnityEngine.SceneManagement;


public class twitterManagerScript : MonoBehaviour {

    // Use this for initialization

    private static bool created = false;
    string filePath;
    string userName;
    TwitterTweetUsersType pastUserData;
    int currentUserIndex = 0;
    bool userExists = false;
    void Awake()
    {
        filePath = Path.Combine(Application.streamingAssetsPath, "playerData.json");
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }
    void Start () {
        updateJSONFile("slimon_slopkins");
    }
    

    //this function will be called once every time someone logs into the game it should:
        //1. Update the login times for the user
        //2. If the user logged in >15 mins ago, call a function to replace the user.data object with
        //   updated user information.
        //3. If the user logged in <15 mins ago, call a function that says that it will not be updated,
        //   and will just use "old" (its 15 mins ago it's not that old) twitter data.
    public void updateJSONFile(string _userName){
       
        userName = _userName;
        string returnText = File.ReadAllText(filePath);
        //error checking here to make sure the file is in the right format. If it is not, write to
        //the JSON file.

        pastUserData = JsonUtility.FromJson<TwitterTweetUsersType>(returnText);
        for (int i = 0; i < pastUserData.tweetUsers.Count; i++){
            if(pastUserData.tweetUsers[i].username == userName){
                print("player exsists in JSON file already");
                currentUserIndex = i;
                userExists = true;
            }
        }
        Twity.Oauth.consumerKey = "b5kQ6Chph2f03h1ioPD6TiJgI";
        Twity.Oauth.consumerSecret = "UtvYmbmbCIYN1DnCDT5VAPFjuw5ivXcFv7FJ2twvF9HccGMPSC";
        Twity.Oauth.accessToken = "4326064273-AxbatafYbYTiCnAXC2WkwzkDgsWUNPbDDgkB5LJ";
        Twity.Oauth.accessTokenSecret = "stv6rOUubQ1ho7TF3d0eQIYpMBJlqfUqCzgxefZHuTczj";
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters["screen_name"] = userName;




      
            
        //if there has been less than 15 total calls, it does not matter, and you can
        //just call the API without consequence
        //this currently will automatically update if able to.

        if(pastUserData.APICalls.Count<15){
            StartCoroutine(Twity.Client.Get("followers/list", parameters, getFollowersCallback));
        }
        //at least 15 API calls have been made
        else{
            //if the time between now and the 0th item on the list is less than 15. You can make a call
            //and then pop the first item, and push the current time to the back
            if(getTimeSinceLimitingCall()<15){
                StartCoroutine(Twity.Client.Get("followers/list", parameters, getFollowersCallback));
            }else{
                print("ERROR: trying to make more than 15 API calls in 15 mins");
            }
        }

    }

    double getTicksInMinutes(long ticks){
        return System.TimeSpan.FromTicks(ticks).TotalMinutes;
    }

    //returns how much time is left before next valid update
    void updateAPICalls(){
        pastUserData.APICalls.Add(System.DateTime.Now.Ticks);
        //if this puts the count of the list over 15, then remove the 0th term.
        if(pastUserData.APICalls.Count>15){
            pastUserData.APICalls.RemoveAt(0);
        }

        if (File.Exists(filePath))
        {
            File.WriteAllText(filePath, JsonUtility.ToJson(pastUserData));
        }
        else
        {
            print("error: file does not exist");
        }

    }
    double getTimeSinceLimitingCall(){
        //API calls are a list of the last 15 API calls. If the last one is less than 15 minutes of the
        //current attempted one, do not let them make another API call.
        long timeSinceLimitingCall = System.DateTime.Now.Ticks - pastUserData.APICalls[0];
        return getTicksInMinutes(timeSinceLimitingCall);
    }


    // Update is called once per frame
    void Update () {
       
    }
  

    //this fuction will get all of the followers and store them to a custom data structure
    void getFollowersCallback(bool success, string response){
        print("WARNING: TWITTER API IS BEING ACCESSED");
        if(success){
            //FollowersListIdResponse playerFollowerIds = JsonUtility.FromJson<FollowersListIdResponse>(response);

            //string returnText = File.ReadAllText(filePath);
            //playerFollowers = JsonUtility.FromJson<FollowersListType>(response);

            GameUserType newUser = new GameUserType();
            //this is what happens if the user has never played before/ they are not
            //in the JSON database
            if(!userExists){
                newUser.data = JsonUtility.FromJson<TwitterFollowerList>(response);
                newUser.username = userName;
                newUser.lastLogin = System.DateTime.Now.Ticks;
                pastUserData.tweetUsers.Add(newUser);
            }
            //otherwise modify the existing user in the pastUserData JSON file
            else{
                pastUserData.tweetUsers[currentUserIndex].data = JsonUtility.FromJson<TwitterFollowerList>(response);
                pastUserData.tweetUsers[currentUserIndex].lastLogin = System.DateTime.Now.Ticks;
            }

            updateAPICalls();

            if (File.Exists(filePath)){
                File.WriteAllText(filePath, JsonUtility.ToJson(pastUserData));
            }else{
                print("error: file does not exist");
            }
        }
        else{
            print("failed with: " + response);
        }
    }

}
