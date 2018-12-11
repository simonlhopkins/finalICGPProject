using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PreviousUsersLoader : MonoBehaviour {

    private string[] previousJSONFiles;
    public RectTransform contentContainer;
    public GameObject existingUserTextGO;
    public float buttonHeight;
	// Use this for initialization
	void Start () {
        previousJSONFiles = Directory.GetFiles(Application.streamingAssetsPath, "*.json");
        for(int i=0; i<previousJSONFiles.Length; i++) {
            print(previousJSONFiles[i]);
        }
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
            newExistingUser.GetComponentInChildren<Text>().text = Path.GetFileName(previousJSONFiles[i]);

        }
    }
}
