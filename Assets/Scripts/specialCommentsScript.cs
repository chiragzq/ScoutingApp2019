using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class specialCommentsScript : MonoBehaviour
{
    public InputField teamNum1, teamNum2, teamNum3, teamNum4, comment1, comment2, comment3, comment4;
    public Button generateQRButton;

    // Start is called before the first frame update
    void Start()
    {
        generateQRButton.onClick.AddListener(loadComments);
    }

    // Update is called once per frame
    void Update()
    {
        if (teamNum1.text.Equals(""))
            comment1.interactable = false;
        else
            comment1.interactable = true;
        if (teamNum2.text.Equals(""))
            comment2.interactable = false;
        else
            comment2.interactable = true;
        if (teamNum3.text.Equals(""))
            comment3.interactable = false;
        else
            comment3.interactable = true;
        if (teamNum4.text.Equals(""))
            comment4.interactable = false;
        else
            comment4.interactable = true;
    }

    void loadComments()
    {
        if (!teamNum1.text.Equals("") ||
            !teamNum2.text.Equals("") ||
            !teamNum3.text.Equals("") ||
            !teamNum4.text.Equals("") ||
            !comment1.text.Equals("") ||
            !comment2.text.Equals("") ||
            !comment3.text.Equals("") ||
            !comment4.text.Equals(""))
        {
            Variables.preload = "";
            Variables.roundData = "";
            Variables.endData = "";
            Variables.teamData = "";
            Variables.commentData = "";
            if (teamNum1.text.Equals(""))
            {
                teamNum1.text = "0";
            }
            if (teamNum2.text.Equals(""))
            {
                teamNum2.text = "0";
            }
            if (teamNum3.text.Equals(""))
            {
                teamNum3.text = "0";
            }
            if (teamNum4.text.Equals(""))
            {
                teamNum4.text = "0";
            }
            Variables.commentData = Variables.commentData
             + Variables.ToBinary(int.Parse(Variables.matchnumber), 7)
             + Variables.ToBinary(int.Parse(teamNum1.text), 13)
             + Variables.ToBinary(int.Parse(teamNum2.text), 13)
             + Variables.ToBinary(int.Parse(teamNum3.text), 13)
             + Variables.ToBinary(int.Parse(teamNum4.text), 13);
            string temp = comment1.text
             + "|" + comment2.text
             + "|" + comment3.text
             + "|" + comment4.text;
            processComment(temp);
            SceneManager.LoadScene("qrgenerator");
        }
    }

    void processComment(string txt)
    {
        char[] list = txt.ToCharArray();
        for (int i = 0; i < list.Length; i++)
        {
            Variables.commentData = Variables.commentData + trans(char.ToLower(list[i]));
        }
    }

    string trans(char c)
    {
        if (c == ' ')
            return "100";
        else if (c == ',')
            return "010";
        else if (c == '.' || c == '!')
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
        else if (c == '|') //used for the divider between the data
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
    }
}
