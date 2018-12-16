using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using JSONclasses;

public class PreviousUsersLoader : MonoBehaviour {

    private string[] previousJSONFiles;
    public RectTransform contentContainer;
    public GameObject existingUserTextGO;
    private GameObject gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("gameManager");
        previousJSONFiles = Directory.GetFiles(Application.streamingAssetsPath, "*.json");
        gameManager.GetComponent<GameStateHandler>().player.GetComponent<Player>().clearContent();
        //buttonHeight = existingUserTextGO.GetComponent<Rect>().height;
        populateContentContainer();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void populateContentContainer() {

        for(int i = 0; i< previousJSONFiles.Length; i++) {
            GameObject newExistingUser = Instantiate(existingUserTextGO, contentContainer.transform, false);
            string userName = Path.GetFileName(previousJSONFiles[i]).Replace(".json", "");
            string lastAccessDate = File.GetLastAccessTime(previousJSONFiles[i]).ToString();

            string dataAsJson = File.ReadAllText(previousJSONFiles[i]);
            GameUserJSON gameUserJSON = JsonUtility.FromJson<GameUserJSON>(dataAsJson);

            newExistingUser.GetComponent<PreviousUserButtonScript>().assocUserName = userName;
            newExistingUser.GetComponentInChildren<Text>().text = userName + " - " + gameUserJSON.lastAccess;

        }
    }



    public void setPlayerUser(string user) {
        print(user);
    }

    public void handleChooseFromScrollBar() {
        print("scrollbar chosen");
    }
}
