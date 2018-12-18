using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using JSONclasses;


public class TwitterManagerScript : MonoBehaviour {


    public string username;
    public bool debugMode;
    private string userJSONFilePath;
    private FriendsIds friendsIds;
    private FriendUsers friendUsers;
    public LogHandler logHandler;
    public GameUserJSON currentGameUserJSON;

	// Use this for initialization
	void Start () {

        logHandler = GetComponent<LogHandler>();
        username = "";

    }

    // Update is called once per frame

	void Update () {

    }

    public void onUserSelected(string _userName) {
        //JSONEnemyHelperGO.GetComponent<JSONEnemyHandler>().loadJSONDataToEnemies(currentGameUserJSON);
        logHandler.writeToLog(_userName + " is being loaded up...", Color.blue);
        userJSONFilePath = Path.Combine(Application.streamingAssetsPath, _userName + ".json");

        //if we are not in debug mode, check if there is a JSON file already created, default to
        //use the most recently made JSON file
        if (!debugMode)
        {
            //create and set the player to the precreated JSON data
            if (File.Exists(userJSONFilePath)){
                string dataAsJson = File.ReadAllText(userJSONFilePath);
                GameUserJSON _gameUserJSON = JsonUtility.FromJson<GameUserJSON>(dataAsJson);
                handleJSONFile(_gameUserJSON.ids, _gameUserJSON.users);

            }
            //if not, then just make a new JSON file from loading
            else {
                updateJSONFile(_userName);
            }

        }
        //if it is in debug mode...
        else
        {
            if (File.Exists(userJSONFilePath)) {
                string dataAsJson = File.ReadAllText(userJSONFilePath);
                GameUserJSON _gameUserJSON = JsonUtility.FromJson<GameUserJSON>(dataAsJson);
                handleJSONFile(_gameUserJSON.ids, _gameUserJSON.users);
            }
            else {
                logHandler.writeToLog("Tried to access " + userJSONFilePath + " but it did not exsist", Color.red);
            }

        }

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
            logHandler.writeToLog("SUCCESS: " + friendsIds.ids.Count + " FOLLOWER IDS were fetched", Color.green);
            //once you have all of the ids you can pass them into another API call for users lookup
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string followersIdsString = string.Join(", ", friendsIds.ids.ToArray());

            parameters["user_id"] = followersIdsString;

            StartCoroutine(Twity.Client.Get("users/lookup", parameters, getFollowerUsersCallback));
            }else{
                print("ERROR: " + response);
                logHandler.writeToLog("ERROR: " + response, Color.red);
            }
            
    }

    void getFollowerUsersCallback(bool success, string response){ 
        if (success){

            friendUsers = JsonUtility.FromJson<FriendUsers>(response);
            logHandler.writeToLog("SUCCESS: " + friendUsers.items.Count + " USERS were fetched", Color.green);

            handleJSONFile(friendsIds, friendUsers);
            
        
        }
        else{
            logHandler.writeToLog("ERROR: " + response, Color.red);

        }
    }

    void handleJSONFile(FriendsIds _friendsIds, FriendUsers _friendUsers){
        bool userExisted = true;
        if (!File.Exists(userJSONFilePath)){
            //create a new JSON file to edit and write the basic structure to it.
            string starterJSONText = "{\"ids\": {}, \"users\": {}, \"lastAccess\": {}}";
            byte[] starterJSONByteArray = System.Text.Encoding.ASCII.GetBytes(starterJSONText);
            logHandler.writeToLog("creating new file: " + userJSONFilePath, Color.green);
            File.WriteAllBytes(userJSONFilePath, starterJSONByteArray);
            userExisted = false;

        }

        string dataAsJson = File.ReadAllText(userJSONFilePath);
        GameUserJSON _gameUserJSON = JsonUtility.FromJson<GameUserJSON>(dataAsJson);

        _gameUserJSON.ids = _friendsIds;
        _gameUserJSON.users = _friendUsers;

        if (!userExisted) {
            _gameUserJSON.lastAccess = System.DateTime.Now.ToString();
        }


        currentGameUserJSON = _gameUserJSON;
        GetComponent<GameStateHandler>().player.GetComponent<Player>().gameUserJSON = currentGameUserJSON;
        GetComponent<GameStateHandler>().player.GetComponent<Player>().followerCount = _friendsIds.ids.Count;
        dataAsJson = JsonUtility.ToJson(_gameUserJSON);
        File.WriteAllText(userJSONFilePath, dataAsJson);
        GetComponent<JSONEnemyHandler>().loadJSONDataToEnemies(currentGameUserJSON);
        //write back to the file path the modified gameUserJSON


    }
}

