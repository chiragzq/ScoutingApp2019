using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostAnalysis : MonoBehaviour
{
    public Button endButton;
    public Toggle assisting, assisted, cl1, cl21, cl22, cl3;
    // public InputField defenseRating;
    private bool go = true;

    private int climbLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        Variables.endData = "";
        endButton.onClick.AddListener(loadClimbLevel);
        endButton.onClick.AddListener(loadAssistsAndDefense);
        endButton.onClick.AddListener(loadNextScene);
    }

    // Update is called once per frame
    void Update()
    {
        // if (defenseRating.text.Equals("")
        //     || defenseRating.text.Equals("1")
        //     || defenseRating.text.Equals("2")
        //     || defenseRating.text.Equals("3")
        //     || defenseRating.text.Equals("4")
        //     || defenseRating.text.Equals("5"))
        //     go = true;
        // else
        //     go = false;
    }


    void loadClimbLevel()
    {
        if (go)
        {
            if (cl1.isOn)
            {
                climbLevel = 1;
            }
            else if (cl21.isOn || cl22.isOn)
            {
                climbLevel = 2;
            }
            else if (cl3.isOn)
            {
                climbLevel = 3;
            }
            else
            {
                climbLevel = 0;
            }
            Variables.endData = Variables.endData + Variables.ToBinary(climbLevel, 2);
        }
    }

    void loadAssistsAndDefense()
    {
        if (go)
        {
            if (assisted.isOn)
                Variables.endData = Variables.endData + "1";
            else
                Variables.endData = Variables.endData + "0";

            if (assisting.isOn)
                Variables.endData = Variables.endData + "1";
            else
                Variables.endData = Variables.endData + "0";
            int temp = 5;
            // if (defenseRating.text.Equals("")) ignore defense rating
            //     temp = 5;
            // else
            //     temp = int.Parse(defenseRating.text) - 1;
            Variables.endData = Variables.endData + Variables.ToBinary(temp, 3);
        }
    }

    void loadNextScene()
    {
        if (go)
            SceneManager.LoadScene("verification");
    }
}
