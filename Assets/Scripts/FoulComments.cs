using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FoulComments : MonoBehaviour
{
    public Button addFoulButton, generateQRButton;
    public InputField foulNumber;
    public Toggle pin, cross, extend, techFoul;
    public Dropdown teamNums;
    // Start is called before the first frame update
    void Start()
    {
        teamNums.AddOptions(Variables.foulTeams);
        Variables.teamData = Variables.ToBinary(int.Parse(Variables.matchnumber),7);
        for (int i = 0; i < 6; i++)
            Variables.teamData = Variables.teamData + Variables.ToBinary(int.Parse(Variables.foulTeams[i]), 13);
        addFoulButton.onClick.AddListener(addFoul);
        generateQRButton.onClick.AddListener(loadNextScene);
    }

    // Update is called once per frame
    void Update()
    {
        if (techFoul.isOn)
            techFoul.GetComponentInChildren<Text>().text = "Tech Foul";
        else
            techFoul.GetComponentInChildren<Text>().text = "Regular Foul";
        if (foulNumber.text.Equals(""))
        {
            pin.interactable = true;
            cross.interactable = true;
            extend.interactable = true;
        }
        else
        {
            pin.isOn = false;
            cross.isOn = false;
            extend.isOn = false;
            pin.interactable = false;
            cross.interactable = false;
            extend.interactable = false;
        }
    }

    void loadNextScene()
    {
        SceneManager.LoadScene("FoulCards");
    }

    void addFoul()
    {
        if (pin.isOn || cross.isOn || extend.isOn || !foulNumber.text.Equals(""))
        {
            string temp = "";
            if (pin.isOn)
                temp = "0101"; //change to correct index
            else if (cross.isOn)
                temp = "0000"; // change to correct index
            else if (extend.isOn)
                temp = "0010"; // change to correct index
            else
                temp = Variables.ToBinary(int.Parse(foulNumber.text), 4);
            string tfoul;
            if (techFoul.isOn)
                tfoul = "1";
            else
                tfoul = "0";
            Variables.commentData = Variables.commentData + Variables.ToBinary(teamNums.value, 3) + temp + tfoul;
            techFoul.isOn = false;
            pin.isOn = false;
            cross.isOn = false;
            extend.isOn = false;
            foulNumber.text = "";
        }
    }
}
