using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class textfile : MonoBehaviour
{
    public Dropdown matches;
    public Button generateQR, backButton, next, previous;

    private int placeholder = 0;
    private static string temporaryString;
    // Start is called before the first frame update
    void Start()
    {
        Variables.roundInfo = new List<string> { };
        //roundInfo = new List<string> { "a", "b", "c" };
        int temporaryCount = PlayerPrefs.GetInt("totalCodes");
        //Debug.Log(PlayerPrefs.GetInt("totalCodes"));
        for (int i = PlayerPrefs.GetInt("totalCodes") - 1; i >= 0; i--)
        {
            string temp = PlayerPrefs.GetString("roundInfo" + i);
            Variables.roundInfo.Add(temp);
        }
        loadList();
        next.onClick.AddListener(nextValues);
        previous.onClick.AddListener(prevValues);
        generateQR.onClick.AddListener(generate);
        backButton.onClick.AddListener(loadPrevScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void nextValues()
    {
        if (placeholder < Variables.roundInfo.Count - 6)
        {

            placeholder = placeholder + 6;
            loadList();
        }
    }

    void prevValues()
    {
        if (placeholder - 6 >= 0)
        {
            placeholder = placeholder - 6;
            loadList();
        }
    }

    void loadList()
    {
        matches.ClearOptions();
        List<string> temporaryList = new List<string> { };
        if (Variables.roundInfo.Count > placeholder + 6)
        {
            for (int i = 0; i < 6; i++)
            {
                temporaryList.Add(Variables.roundInfo[placeholder + i]);
            }
        }
        else
        {
            for (int i = 0; i < Variables.roundInfo.Count - placeholder; i++)
                temporaryList.Add(Variables.roundInfo[placeholder + i]);
        }
        matches.AddOptions(temporaryList);
    }

    void generate()
    {
        if (PlayerPrefs.GetInt("totalCodes") > 0)
        {
            Variables.preload = "";
            Variables.roundData = "";
            Variables.endData = "";
            Variables.teamData = "";
            Variables.commentData = "";
            temporaryString = PlayerPrefs.GetString("" + (PlayerPrefs.GetInt("totalCodes") - matches.value - 1), "");
            Variables.commentData = temporaryString;
            Variables.recordQR = true;
            SceneManager.LoadScene("qrgenerator");
        }
    }

    void loadPrevScene()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
