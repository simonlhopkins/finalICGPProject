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
    public float buttonHeight;
	// Use this for initialization
	void Start () {
        previousJSONFiles = Directory.GetFiles(Application.streamingAssetsPath, "*.json");

        //buttonHeight = existingUserTextGO.GetComponent<Rect>().height;
        populateContentContainer();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void populateContentContainer() {

        Vector3 startPostion = new Vector3(-291f, 139, 0f);
        int totalHeight =0;
        float padding = 10f;

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
