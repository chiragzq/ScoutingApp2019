using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Username : MonoBehaviour
{
    public Button loginButton;
    public InputField username;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("username") && PlayerPrefs.HasKey("version"))
        {
            if (PlayerPrefs.GetString("version").Equals(Variables.version))
                SceneManager.LoadScene("ModeSelection");
        }
        loginButton.onClick.AddListener(setUsername);

    }

    void setUsername()
    {
        int ind = findIndex();
        if (ind != -1)
        {
            PlayerPrefs.SetString("user", Variables.ToBinary(ind, 6));
            if (ind != Variables.users.Length-1)
                PlayerPrefs.SetString("username", username.text.Substring(2, username.text.Length - 3).ToUpper());
            else
                PlayerPrefs.SetString("username", username.text.Substring(0).ToUpper());
            PlayerPrefs.SetString("version", Variables.version);
            SceneManager.LoadScene("ModeSelection");
        }
    }

    int findIndex()
    {
        string temp = username.text.ToLower();
        for (int i = 0; i < Variables.users.Length; i++)
        {
            if (temp.Equals(Variables.users[i]))
                return i;
        }
        return -1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
