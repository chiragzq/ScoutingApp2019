using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FoulCardsScript : MonoBehaviour
{

    public Text[] teamTxts = new Text[6];
    public Toggle y1, r1, y2, r2, y3, r3, y4, r4, y5, r5, y6, r6;
    public Button generateButton,backButton;
    public InputField comment;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            teamTxts[i].text = Variables.foulTeams[i];
        }
        generateButton.onClick.AddListener(recordCards);
        backButton.onClick.AddListener(previousScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void previousScene()
    {
        SceneManager.LoadScene("FoulsComments");
    }

    void recordCards()
    {
        Variables.commentData = Variables.commentData + "111"
            + convertToggle(y1) + convertToggle(r1)
            + convertToggle(y2) + convertToggle(r2)
            + convertToggle(y3) + convertToggle(r3)
            + convertToggle(y4) + convertToggle(r4)
            + convertToggle(y5) + convertToggle(r5)
            + convertToggle(y6) + convertToggle(r6)
            + processComment(comment.text);
        SceneManager.LoadScene("qrgenerator");

    }

    string convertToggle(Toggle t)
    {
        if (t.isOn)
            return "1";
        else
            return "0";
    }

    string processComment(string txt)
    {
        string temp = "";
        char[] list = txt.ToCharArray();
        for (int i = 0; i < list.Length; i++)
        {
            temp = temp + trans(char.ToLower(list[i]));
        }
        return temp;
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
        else if (c == '|')
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
