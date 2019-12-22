using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{

    public Button leftButton, rightButton, recordsButton, eraseButton;
    public InputField teamnum, matchnum;
    public Toggle red, blue;
    public Text notificationText, usernameText;
    // Use this for initialization
    void Start()
    {
        //  PlayerPrefs.DeleteAll();   
        if (PlayerPrefs.GetString("role").Equals("Scouting"))
            Variables.roleBits = "000";
        else if (PlayerPrefs.GetString("role").Equals("Assistant"))
            Variables.roleBits = "001";
        else if (PlayerPrefs.GetString("role").Equals("Strategy"))
            Variables.roleBits = "010";
        else if (PlayerPrefs.GetString("role").Equals("Defense"))
            Variables.roleBits = "011";
        else if (PlayerPrefs.GetString("role").Equals("Fouls"))
            Variables.roleBits = "100";

        if (!PlayerPrefs.GetString("role").Equals("Scouting"))
        {
            leftButton.GetComponentInChildren<Text>().text = "Start";
            rightButton.GetComponentInChildren<Text>().text = "";
            rightButton.interactable = false;
            red.interactable = false;
            blue.interactable = false;
            teamnum.interactable = false;
        }
        else
        {
            rightButton.onClick.AddListener(setRightBool);
        }
        if (PlayerPrefs.GetString("role").Equals("Scouting"))
        {
            leftButton.onClick.AddListener(loadNextScene);
        }
        else if (PlayerPrefs.GetString("role").Equals("Strategy") || PlayerPrefs.GetString("role").Equals("Assistant")
        || PlayerPrefs.GetString("role").Equals("Fouls") || PlayerPrefs.GetString("role").Equals("Defense"))
        {
            leftButton.onClick.AddListener(loadCommentsScene);
        }
        recordsButton.onClick.AddListener(loadRecordsScene);
        eraseButton.onClick.AddListener(erasePlayerPrefs);
    }

    void Update()
    {
        Variables.teamnumber = teamnum.text;
        Variables.matchnumber = matchnum.text;

        string role = PlayerPrefs.GetString("role");
        if(role == "Assistant")
            role = "Qualitative";
        else
            role = "Game Pieces";
        if (PlayerPrefs.HasKey("username"))
        {
            usernameText.text = "Hello " + PlayerPrefs.GetString("username") + ", your role is " + role + ".";
        }
        if (!PlayerPrefs.HasKey("totalCodes"))
        {
            PlayerPrefs.SetInt("totalCodes", 0);
        }
    }

    void loadCommentsScene()
    {
        if (!matchnum.text.Equals("")
        && int.Parse(matchnum.text) < 128 && int.Parse(matchnum.text) > 0)
        {
            if (PlayerPrefs.GetString("role").Equals("Defense"))
                SceneManager.LoadScene("SpecialComments");
            else if (PlayerPrefs.GetString("role").Equals("Fouls"))
                SceneManager.LoadScene("FoulTeams");
            else if (PlayerPrefs.GetString("role").Equals("Assistant") || PlayerPrefs.GetString("role").Equals("Strategy"))
                SceneManager.LoadScene("FoulTeams");
        }
    }

    void loadRoleSelectScene()
    {
        PlayerPrefs.DeleteKey("role");
        SceneManager.LoadScene("ModeSelection");
    }

    void erasePlayerPrefs()
    {
        if (matchnum.text.Equals("678") && teamnum.text.Equals(""))
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("records");
        }
        else if (matchnum.text.Equals("365") && teamnum.text.Equals(""))
        {
            PlayerPrefs.DeleteKey("username");
            PlayerPrefs.DeleteKey("user");
            SceneManager.LoadScene("Login");
        }
        else if (matchnum.text.Equals("408") && teamnum.text.Equals("0639"))
        {
            Variables.devMode = !Variables.devMode;
            notificationText.text = "DevMode activated";
        }
        else
            loadRoleSelectScene();
    }

    void setRightBool()
    {
        if (!teamnum.text.Equals("") && !matchnum.text.Equals(""))
        {
            Variables.right = true;
            loadNextScene();
        }
    }

    void loadTeamColor()
    {
        if (red.isOn)
        {
            Variables.teamColor = "0"; //teamcolor is set to red
            Debug.Log("red");
        }
        else
        {
            Variables.teamColor = "1";
            Debug.Log("blue");
        }
    }

    void loadRecordsScene()
    {
        SceneManager.LoadScene("records");
    }

    void loadNextScene()
    {
        if (!teamnum.text.Equals("") && !matchnum.text.Equals("")
        && int.Parse(matchnum.text) < 128 && int.Parse(matchnum.text) > 0
        && int.Parse(teamnum.text) < 8192 && int.Parse(teamnum.text) > 0)
        {
            loadTeamColor();
            SceneManager.LoadScene(Variables.sceneIdentifier() + "PreRound");
        }
    }
}
