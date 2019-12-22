using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoShow : MonoBehaviour
{
    public InputField teamnum;
    public Button yesButton, noButton;

    // Use this for initialization
    void Start()
    {
        teamnum.text = Variables.teamnumber;
        yesButton.onClick.AddListener(loadNextScene);
        noButton.onClick.AddListener(back);
    }

    // Update is called once per frame
    void Update()
    {
        Variables.teamnumber = teamnum.text;
    }
    void loadNextScene()
    {
        Variables.preload = "101";
        for (int i = 0; i < 7; i++)
            Variables.preload = Variables.preload + "0";
        for (int i = 0; i < 37; i++)
            Variables.roundData = Variables.roundData + "0";
        for (int i = 0; i < 7; i++)
            Variables.endData = Variables.endData + "0";
        //for (int i = 0; i < 21; i++)
            //Variables.teamData = Variables.teamData + "0";

        if (!teamnum.text.Equals(""))
            SceneManager.LoadScene("comments");
    }
    void back()
    {
        SceneManager.LoadScene(Variables.sceneIdentifier() + "PreRound");
    }

}
