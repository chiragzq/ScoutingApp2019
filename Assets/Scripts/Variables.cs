using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Variables : MonoBehaviour
{
    public static string version = "1.5.6";

    public static string teamnumber = "";
    public static string matchnumber = "";
    public static string teamColor = "1";
    public static string preload = "";
    public static int startingPosition = 0;
    public static string roundData = "";
    public static string endData = "";
    public static string teamData = "";
    public static int lowCargoCount = 0;
    public static int lowHatchCount = 0;
    public static int midCargoCount = 0;
    public static int midHatchCount = 0;
    public static int highCargoCount = 0;
    public static int highHatchCount = 0;
    public static int defenseTime = 0;
    public static bool right = false;
    public static string commentData = "";
    public static bool recordQR = false;
    public static bool devMode = false;
    public static List<string> roundInfo = new List<string> { };
    public static List<string> foulTeams = new List<string> { }; // always 6
    public static string roleBits = "";
    // public static string[] users = { 
    // "22shahzebl", 
    // "21chloea", 
    // "22pranavg",
    // "20neals",
    // "19rahulg",
    // "22chiragk",
    // "21harib",
    // "19joelm",
    // "21ethans",
    // "19djm",
    // "19puneetn",
    // "22adheetg",
    // "21aditiv",
    // "19andrewc",
    // "19christopherl",
    // "20finnf",
    // "21angelac",
    // "20sanjayr",
    // "19carlg",
    // "20jatink",
    // "22ethanc",
    // "22kateo",
    // "19charlesp",
    // "22gloriaz",
    // "22angiej",
    // "22prakritj",
    // "21arthurj",
    // "20rohans",
    // "21aydint",
    // "21ankitak",
    // "19ryana",
    // "22kailashr",
    // "22anishp",
    // "22alivial",
    // "20quentinc",
    // "22zachc",
    // "22austinw",
    // "22dennisg",
    // "22arnavg",
    // "22dawsonc",
    // "22pranavv",
    // "22alexl",
    // "22raymondx",
    // "22bobbyw",
    // "22willy",
    // "22aimeew",
    // "20nashm",
    // "20sahilg",
    // "22harshd",
    // "22rohanr",
    // "guest"
    // };

     public static string[] users = { 
    "23emmab",
"22arjund",
"22alicef",
"23adap",
"21shalinir",
"23ariyar",
"23williaml",
"22nikkik",
"22aimeew",
"22connorw",
"21angelac",
"23gavinr",
"22alexal",
"22dennisg",
"21arthurj",
"21ankitak",
"22chiragk",
"22gloriaz",
"20jatink",
"22angiej",
"22ethanc",
"20quentinc",
"22zachc",
"22prakritj",
"20finnf",
"21harib",
"20sanjayr",
"22kateo",
"22shahzebl",
"22pranavg",
"21aditiv",
"kaitlin",
"rachel",
"anand",
"guest"
    };

    //public static bool t1, t2, t3, t4, t5, t6;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static string ToBinary(int aVal, int aDigits)
    {
        string result = "";
        for (int i = 0; i < aDigits; i++)
        {
            if ((aVal & (1 << i)) != 0)
                result = "1" + result;
            else
                result = "0" + result;
        }
        /* while (result[0].Equals('0'))
         {
             result = result.Substring(1);
         }*/
        return result;
    }

    public static int ToDec(string val)
    {
        int result = 0;
        for (int i = 0; i < val.Length; i++)
        {
            result = result + int.Parse(val.Substring(val.Length - 1 - i, 1))* (int)Mathf.Pow(2, i);
        }
        return result;
    }

    public static string sceneIdentifier()
    {
        string temp = "";
        if (right)
            temp = temp + "Right";
        else
            temp = temp + "Left";
        if (teamColor.Equals("1"))
            temp = temp + "Blue";
        else if (teamColor.Equals("0"))
            temp = temp + "Red";
        return temp;
    }

    public static void reset()
    {
        teamnumber = "";
        matchnumber = "";
        teamColor = "1";
        preload = "";
        startingPosition = 0;
        roundData = "";
        endData = "";
        teamData = "";
        lowCargoCount = 0;
        lowHatchCount = 0;
        midCargoCount = 0;
        midHatchCount = 0;
        highCargoCount = 0;
        highHatchCount = 0;
        defenseTime = 0;
        right = false;
        commentData = "";
        roundInfo = new List<string> { };
        foulTeams = new List<string> { };
        roleBits = "";
    }
}
