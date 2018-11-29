using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using JSONclasses;

public class twitterManagerScript2 : MonoBehaviour {


    public string username;
    public bool debugMode;
    private string userJSONFilePath;
    private FriendsIds friendsIds;
    private FriendUsers friendUsers;
    public GameObject JSONEnemyHelperGO;
	// Use this for initialization
	void Start () {
        
        userJSONFilePath = Path.Combine(Application.streamingAssetsPath, username + ".json");

        if(!debugMode){
            updateJSONFile(username);
        }
        else{

            string dataAsJson = File.ReadAllText(userJSONFilePath);
            GameUserJSON gameUserJSON = JsonUtility.FromJson<GameUserJSON>(dataAsJson);
            JSONEnemyHelperGO.GetComponent<JSONEnemyHandler>().loadJSONDataToEnemies(gameUserJSON);
        }


    }
	
	// Update is called once per frame
	void Update () {
        
	}


    public void updateJSONFile(string _userName)
    {
        
        Twity.Oauth.consumerKey = "b5kQ6Chph2f03h1ioPD6TiJgI";
        Twity.Oauth.consumerSecret = "UtvYmbmbCIYN1DnCDT5VAPFjuw5ivXcFv7FJ2twvF9HccGMPSC";
        Twity.Oauth.accessToken = "4326064273-AxbatafYbYTiCnAXC2WkwzkDgsWUNPbDDgkB5LJ";
        Twity.Oauth.accessTokenSecret = "stv6rOUubQ1ho7TF3d0eQIYpMBJlqfUqCzgxefZHuTczj";
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters["screen_name"] = _userName;
        parameters["count"] = "100";

        StartCoroutine(Twity.Client.Get("friends/ids", parameters, getFollowerIdsCallback));





    }
    void getFollowerIdsCallback(bool success, string response){
        if(success){
            
            friendsIds = JsonUtility.FromJson<FriendsIds>(response);
            print("SUCCESS: " + friendsIds.ids.Count + " FOLLOWER IDS were fetched");

            //once you have all of the ids you can pass them into another API call for users lookup
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string followersIdsString = string.Join(", ", friendsIds.ids.ToArray());
            print(followersIdsString);
            parameters["user_id"] = followersIdsString;

            StartCoroutine(Twity.Client.Get("users/lookup", parameters, getFollowerUsersCallback));
            }else{
                print("ERROR: " + response);
            }
            
    }

    void getFollowerUsersCallback(bool success, string response){ 
        if (success){

            friendUsers = JsonUtility.FromJson<FriendUsers>(response);
            print(response);
            print("SUCCESS: " + friendUsers.items.Count + " USERS were fetched");

            handleJSONFile(friendsIds, friendUsers);
        
        }
        else{
            print("ERROR: " + response);
        }
    }

    void handleJSONFile(FriendsIds _friendsIds, FriendUsers _friendUsers){
        if (!File.Exists(userJSONFilePath)){
            //create a new JSON file to edit and write the basic structure to it.
            string starterJSONText = "{\"followerids\": {}, \"followerUserObjects\": {} }";
            byte[] starterJSONByteArray = System.Text.Encoding.ASCII.GetBytes(starterJSONText);
            print("creating new file: " + userJSONFilePath);
            File.WriteAllBytes(userJSONFilePath, starterJSONByteArray);

        }
        string dataAsJson = File.ReadAllText(userJSONFilePath);
        GameUserJSON gameUserJSON = JsonUtility.FromJson<GameUserJSON>(dataAsJson);
        gameUserJSON.ids = _friendsIds;
        gameUserJSON.users = _friendUsers;
        //write back to the file path the modified gameUserJSON
        File.WriteAllText(userJSONFilePath, JsonUtility.ToJson(gameUserJSON));



        JSONEnemyHelperGO.GetComponent<JSONEnemyHandler>().loadJSONDataToEnemies(gameUserJSON);
    }
}
