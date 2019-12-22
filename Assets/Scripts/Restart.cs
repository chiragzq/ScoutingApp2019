using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Restart : MonoBehaviour
{
    public Button restartButton, nextButton, prevButton;
    public Text label;

    private string allData;
    private static int temp;

    // Use this for initialization
    void Start()
    {
        if (!Variables.recordQR)
        {
            if (PlayerPrefs.GetString("role").Equals("Scouting"))
            {
                allData = Variables.roleBits + Variables.preload + Variables.roundData + Variables.endData + Variables.teamData + PlayerPrefs.GetString("user") + Variables.commentData + "";
            }
            else if (PlayerPrefs.GetString("role").Equals("Strategy") || PlayerPrefs.GetString("role").Equals("Assistant")
            || PlayerPrefs.GetString("role").Equals("Fouls") || PlayerPrefs.GetString("role").Equals("Defense"))
                allData = Variables.roleBits + PlayerPrefs.GetString("user") + Variables.teamData + Variables.commentData;
            temp = PlayerPrefs.GetInt("totalCodes");
            PlayerPrefs.SetInt("totalCodes", temp + 1);
            PlayerPrefs.SetString(temp + "", allData);
            PlayerPrefs.SetString("role" + temp, PlayerPrefs.GetString("role"));
            PlayerPrefs.SetString("roundInfo" + temp, "Match: " + Variables.matchnumber + ", Team: " + Variables.teamnumber);
        }
        else
        {
            allData = Variables.commentData;
        }
        int ind = -1;
        for (int i = 0; i < PlayerPrefs.GetInt("totalCodes"); i++)
        {
            if (allData.Equals(PlayerPrefs.GetString(i + "")))
                ind = i;
        }
        Debug.Log(ind + "lmao");
        if (PlayerPrefs.GetString("role" + ind).Equals("Scouting"))
            label.text = "Match: " + Variables.ToDec(allData.Substring(70, 7)) + "; Team: " + Variables.ToDec(allData.Substring(57, 13)) + " - " + PlayerPrefs.GetString("role" + ind);
        else if (PlayerPrefs.GetString("role" + ind).Equals("Assistant") || PlayerPrefs.GetString("role" + ind).Equals("Strategy") || PlayerPrefs.GetString("role" + ind).Equals("Fouls"))
            label.text = "Match: " + Variables.ToDec(allData.Substring(9, 7)) + " - " + PlayerPrefs.GetString("role" + ind);
        else if (PlayerPrefs.GetString("role" + ind).Equals("Defense"))
        {
            label.text = "Match: " + Variables.ToDec(allData.Substring(9, 7)) + "; Teams: ";
            if (Variables.ToDec(allData.Substring(16, 13)) != 0)
            {
                label.text = label.text + Variables.ToDec(allData.Substring(16, 13)) + ", ";
            }
            if (Variables.ToDec(allData.Substring(29, 13)) != 0)
            {
                label.text = label.text + Variables.ToDec(allData.Substring(29, 13)) + ", ";
            }
            if (Variables.ToDec(allData.Substring(42, 13)) != 0)
            {
                label.text = label.text + Variables.ToDec(allData.Substring(42, 13)) + ", ";
            }
            if (Variables.ToDec(allData.Substring(55, 13)) != 0)
            {
                label.text = label.text + Variables.ToDec(allData.Substring(55, 13)) + ", ";
            }
            label.text = label.text.Substring(0, label.text.Length - 2) + " - " + PlayerPrefs.GetString("role" + ind);
        }
        nextButton.onClick.AddListener(loadNextQR);
        prevButton.onClick.AddListener(loadPrevQR);
        restartButton.onClick.AddListener(loadNextScene);
    }

    void Update()
    {
    }

    void loadNextScene()
    {
        Variables.reset();
        SceneManager.LoadScene("mainmenu");
    }

    void loadNextQR()
    {
        if (PlayerPrefs.GetInt("totalCodes") > 0)
        {
            int index = -1;
            for (int i = 0; i < PlayerPrefs.GetInt("totalCodes")-1; i++)
            {
                if (allData.Equals(PlayerPrefs.GetString(i + "")))
                    index = i;
            }
            Debug.Log(index);
            if (index >= 0)
            {
                Variables.preload = "";
                Variables.roundData = "";
                Variables.endData = "";
                Variables.teamData = "";
                Variables.commentData = "";
                Variables.commentData = PlayerPrefs.GetString("" + (index + 1));
                Variables.recordQR = true;
                SceneManager.LoadScene("qrgenerator");
            }
        }
    }

    void loadPrevQR()
    {
        if (PlayerPrefs.GetInt("totalCodes") > 0)
        {
            int index = -1;
            int index2 = -1;
            for (int i = 1; i < PlayerPrefs.GetInt("totalCodes"); i++)
            {
                if (allData.Equals(PlayerPrefs.GetString(i + "")))
                    index = i;
            }
            for (int i = PlayerPrefs.GetInt("totalCodes")-1; i > 0; i--)
            {
                if (allData.Equals(PlayerPrefs.GetString(i + "")))
                    index2 = i;
            }
            Debug.Log(index + ", " + index2);
            if (index >= 0 && index2 >= 0)
            {
                if (index2 < index)
                {
                    index = index2;
                }
                Variables.preload = "";
                Variables.roundData = "";
                Variables.endData = "";
                Variables.teamData = "";
                Variables.commentData = "";
                Variables.commentData = PlayerPrefs.GetString("" + (index-1));
                Variables.recordQR = true;
                SceneManager.LoadScene("qrgenerator");
            }
        }
    }


}
