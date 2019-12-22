using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comments : MonoBehaviour
{
    public InputField comment;
    public Button generateQRButton;

    // Start is called before the first frame update
    void Start()
    {
        generateQRButton.onClick.AddListener(loadNextScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void loadNextScene()
    {
        if (!comment.GetComponentInChildren<Text>().text.Equals(""))
            processComment(comment.GetComponentInChildren<Text>().text);
        if (PlayerPrefs.GetString("role").Equals("Scouting"))
            Variables.teamData = Variables.ToBinary(int.Parse(Variables.teamnumber), 13) + Variables.ToBinary(int.Parse(Variables.matchnumber), 7) + Variables.teamColor;
        else if (PlayerPrefs.GetString("role").Equals("Strategy") || PlayerPrefs.GetString("role").Equals("Assistant")
        || PlayerPrefs.GetString("role").Equals("Fouls") || PlayerPrefs.GetString("role").Equals("Defense")) {
            Variables.teamData = Variables.ToBinary(int.Parse(Variables.matchnumber), 7);
            Variables.teamData = Variables.teamData + Variables.ToBinary(int.Parse(Variables.foulTeams[0]), 13);
            Variables.teamData = Variables.teamData + Variables.ToBinary(int.Parse(Variables.foulTeams[1]), 13);
            Variables.teamData = Variables.teamData + Variables.ToBinary(int.Parse(Variables.foulTeams[2]), 13);
        }

        Variables.recordQR = false;
        SceneManager.LoadScene("qrgenerator");
    }

    void processComment(string txt)
    {
        char[] list = txt.ToCharArray();
        for (int i = 0; i < list.Length; i++)
        {
            Debug.Log(char.ToLower(list[i]) + ": " + trans(char.ToLower(list[i])));
            Variables.commentData = Variables.commentData + trans(char.ToLower(list[i]));
        }
        Debug.Log(Variables.commentData.Length);
    }

    string trans(char c)
    {
        if (c == ' ')
            return "100";
        else if (c == ',')
            return "010";
        else if (c == '.')
            return "001";
        else if (c == 'e')
            return "1011";
        else if (c == 't')
            return "0001";
        else if (c == 'a')
            return "11111";
        else if (c == 'o')
            return "11100";
        else if (c == 'n')
            return "11010";
        else if (c == 'i')
            return "11001";
        else if (c == 's')
            return "10101";
        else if (c == 'r')
            return "10100";
        else if (c == 'h')
            return "01111";
        else if (c == 'd')
            return "00001";
        else if (c == 'l')
            return "00000";
        else if (c == 'u')
            return "011101";
        else if (c == 'c')
            return "011100";
        else if (c == 'm')
            return "011010";
        else if (c == 'f')
            return "011001";
        else if (c == 'w')
            return "011000";
        else if (c == 'g')
            return "1111011";
        else if (c == '9')
            return "1111010";
        else if (c == '2')
            return "1111001";
        else if (c == '1')
            return "1111000";
        else if (c == '4')
            return "1110111";
        else if (c == '3')
            return "1110110";
        else if (c == '6')
            return "1110101";
        else if (c == '5')
            return "1110100";
        else if (c == '8')
            return "1101111";
        else if (c == '7')
            return "1101110";
        else if (c == '0')
            return "1101101";
        else if (c == 'y')
            return "1101100";
        else if (c == 'p')
            return "1100001";
        else if (c == 'b')
            return "1100000";
        else if (c == 'v')
            return "0110110";
        else if (c == ';')
            return "11000101";
        else if (c == '(' || c == ')')
            return "11000100";
        else if (c == '-')
            return "01101111";
        else if (c == 'k')
            return "01101110";
        else if (c == '?')
            return "110001110";
        else if (c == '!')
            return "110001101";
        else if (c == ':')
            return "110001100";
        else if (c == 'x')
            return "11000111111";
        else if (c == 'j')
            return "11000111110";
        else if (c == 'q')
            return "11000111101";
        else if (c == 'z')
            return "11000111100";
        else
            return "";
        /*          
    if (c == ' ')
        return "111";
    else if (c == 'e')
        return "010";
    else if (c == 't')
        return "1100";
    else if (c == 'a')
        return "1010";
    else if (c == 'o')
        return "1001";
    else if (c == 'n')
        return "0111";
    else if (c == 'i')
        return "0110";
    else if (c == 's')
        return "0011";
    else if (c == 'r')
        return "0010";
    else if (c == 'h')
        return "0001";
    else if (c == 'd')
        return "11010";
    else if (c == 'l')
        return "10110";
    else if (c == 'u')
        return "00001";
    else if (c == 'c')
        return "00000";
    else if (c == 'm')
        return "110111";
    else if (c == 'f')
        return "110110";
    else if (c == 'w')
        return "101110";
    else if (c == 'g')
        return "100011";
    else if (c == 'y')
        return "100010";
    else if (c == 'p')
        return "100001";
    else if (c == 'b')
        return "100000";
    else if (c == 'v')
        return "1011110";
    else if (c == 'k')
        return "10111111";
    else if (c == 'x')
        return "1011111011";
    else if (c == 'j')
        return "1011111010";
    else if (c == 'q')
        return "1011111001";
    else if (c == 'z')
        return "1011111000";
    else
        return "";*/

    }
}
