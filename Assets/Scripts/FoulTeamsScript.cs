using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FoulTeamsScript : MonoBehaviour
{

    public InputField TN1, TN2, TN3;
    public Button recordTeamsButton, backButton;
    // Start is called before the first frame update
    void Start()
    {
        recordTeamsButton.onClick.AddListener(recordTeams);
        backButton.onClick.AddListener(back);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void recordTeams()
    {

        if (!TN1.text.Equals("") && 
            !TN2.text.Equals("") && 
            !TN3.text.Equals(""))
        {
            Variables.foulTeams.Clear();
            Variables.foulTeams.Add(TN1.text);
            Variables.foulTeams.Add(TN2.text);
            Variables.foulTeams.Add(TN3.text);
            SceneManager.LoadScene("comments");
        }
            
    }

    void back()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
