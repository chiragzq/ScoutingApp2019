using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class verifyteamnumber : MonoBehaviour
{
    public InputField teamnum;
    public Button yesButton,backButton;

    // Use this for initialization
    void Start()
    {
        teamnum.text = Variables.teamnumber;
        yesButton.onClick.AddListener(loadNextScene);
        backButton.onClick.AddListener(loadPrevScene);
    }

    // Update is called once per frame
    void Update()
    {
        Variables.teamnumber = teamnum.text;
    }
    void loadNextScene()
    {
        if (!teamnum.text.Equals(""))
            SceneManager.LoadScene("comments");
    }
    void loadPrevScene()
    {
        SceneManager.LoadScene(Variables.sceneIdentifier() + "PostRound");
    }

}
