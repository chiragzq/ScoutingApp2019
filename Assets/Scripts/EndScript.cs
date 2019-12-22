using System.Collections;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EndScript : MonoBehaviour
{
    public Button endButton, errorButton, foulButton, t1, t2, t3, t4, t5, t6, t7, t8;
    /*
     * 0 is +1 cargo
     * 1 is -1 cargo
     * 2 is +1 hatch
     * 3 is -1 hatch
     */
    public Button[] high = new Button[4];
    public Button[] mid = new Button[4];
    public Button[] low = new Button[4];
    public Toggle TD, bricked;
    public Text highrocketHatchCount, highrocketCargoCount, midrocketHatchCount, midrocketCargoCount, lowrocketHatchCount, lowrocketCargoCount;
    public Sprite hatchSprite, cargoSprite, blankSprite, hatchCargoSprite;
    public AudioSource[] audioSources = new AudioSource[4];

    private Stopwatch stopwatch;
    private Stopwatch doubleTapStopwatch;
    private int highrocketHatchCT, highrocketCargoCT = 0;
    private int midrocketHatchCT, midrocketCargoCT = 0;
    private int lowrocketHatchCT, lowrocketCargoCT = 0;
    private int numberOfErrors = 0;
    private int numberOfFouls = 0;

    private bool playedBrickedSound = false;
    private bool playedDefenseSound = false;



    // Use this for initialization
    void Start()
    {
        Variables.roundData = "";
        TD.isOn = false;
        stopwatch = new Stopwatch();
        doubleTapStopwatch = new Stopwatch();
        high[0].onClick.AddListener(plushighcargorocket);
        high[1].onClick.AddListener(minushighcargorocket);
        high[2].onClick.AddListener(plushighhatchrocket);
        high[3].onClick.AddListener(minushighhatchrocket);
        mid[0].onClick.AddListener(plusmidcargorocket);
        mid[1].onClick.AddListener(minusmidcargorocket);
        mid[2].onClick.AddListener(plusmidhatchrocket);
        mid[3].onClick.AddListener(minusmidhatchrocket);
        low[0].onClick.AddListener(pluslowcargorocket);
        low[1].onClick.AddListener(minuslowcargorocket);
        low[2].onClick.AddListener(pluslowhatchrocket);
        low[3].onClick.AddListener(minuslowhatchrocket);
        t1.onClick.AddListener(swapImaget1);
        t2.onClick.AddListener(swapImaget2);
        t3.onClick.AddListener(swapImaget3);
        t4.onClick.AddListener(swapImaget4);
        t5.onClick.AddListener(swapImaget5);
        t6.onClick.AddListener(swapImaget6);
        t7.onClick.AddListener(swapImaget7);
        t8.onClick.AddListener(swapImaget8);
        endButton.onClick.AddListener(loadLowCargoShipCount);
        endButton.onClick.AddListener(loadDefenseCount);
        endButton.onClick.AddListener(loadAllData);
        endButton.onClick.AddListener(loadNextScene);
        errorButton.onClick.AddListener(incrementErrors);
        foulButton.onClick.AddListener(incrementFouls);
    }

    void incrementErrors()
    {
        if (doubleTapStopwatch.IsRunning)
        {
            doubleTapStopwatch.Stop();
            doubleTapStopwatch.Reset();
            if (numberOfErrors > 1)
                numberOfErrors -= 2;
        }
        else if (numberOfErrors < 15)
        {
            audioSources[1].Play();
            numberOfErrors++;
            doubleTapStopwatch.Start();
        }
        else
        {
            doubleTapStopwatch.Start();
        }
    }

    void incrementFouls()
    {
        if (doubleTapStopwatch.IsRunning)
        {
            doubleTapStopwatch.Stop();
            doubleTapStopwatch.Reset();
            if (numberOfFouls > 1)
                numberOfFouls -= 2;
        }
        else if (numberOfFouls < 15)
        {
            audioSources[1].Play();
            numberOfFouls++;
            doubleTapStopwatch.Start();
        }
        else
        {
            doubleTapStopwatch.Start();
        }
    }

    void plushighcargorocket()
    {
        if (Variables.highCargoCount < 4)
        {
            TD.isOn = false;
            audioSources[0].Play();
            Variables.highCargoCount++;
            highrocketCargoCT++;
        }
    }

    void minushighcargorocket()
    {
        if (Variables.highCargoCount > 0)
        {
            audioSources[1].Play();
            Variables.highCargoCount--;
            highrocketCargoCT--;
        }
    }

    void plushighhatchrocket()
    {
        if (Variables.highHatchCount < 4)
        {
            TD.isOn = false;
            audioSources[0].Play();
            Variables.highHatchCount++;
            highrocketHatchCT++;
        }
    }

    void minushighhatchrocket()
    {
        if (Variables.highHatchCount > 0)
        {
            audioSources[1].Play();
            Variables.highHatchCount--;
            highrocketHatchCT--;
        }
    }

    void plusmidcargorocket()
    {
        if (Variables.midCargoCount < 4)
        {
            TD.isOn = false;
            audioSources[0].Play();
            Variables.midCargoCount++;
            midrocketCargoCT++;
        }
    }

    void minusmidcargorocket()
    {
        if (Variables.midCargoCount > 0)
        {
            audioSources[1].Play();
            Variables.midCargoCount--;
            midrocketCargoCT--;
        }
    }

    void plusmidhatchrocket()
    {
        if (Variables.midHatchCount < 4)
        {
            TD.isOn = false;
            audioSources[0].Play();
            Variables.midHatchCount++;
            midrocketHatchCT++;
        }
    }

    void minusmidhatchrocket()
    {
        if (Variables.midHatchCount > 0)
        {
            audioSources[1].Play();
            Variables.midHatchCount--;
            midrocketHatchCT--;
        }
    }

    void pluslowcargorocket()
    {
        if (Variables.lowCargoCount < 4)
        {
            TD.isOn = false;
            audioSources[0].Play();
            Variables.lowCargoCount++;
            lowrocketCargoCT++;
        }
    }

    void minuslowcargorocket()
    {
        if (Variables.lowCargoCount > 0)
        {
            audioSources[1].Play();
            Variables.lowCargoCount--;
            lowrocketCargoCT--;
        }
    }

    void pluslowhatchrocket()
    {
        if (Variables.lowHatchCount < 4)
        {
            TD.isOn = false;
            audioSources[0].Play();
            Variables.lowHatchCount++;
            lowrocketHatchCT++;
        }
    }

    void minuslowhatchrocket()
    {
        if (Variables.lowHatchCount > 0)
        {
            audioSources[1].Play();
            Variables.lowHatchCount--;
            lowrocketHatchCT--;
        }
    }

    void swapImaget1()
    {
        swapImage(t1);
    }
    void swapImaget2()
    {
        swapImage(t2);
    }
    void swapImaget3()
    {
        swapImage(t3);
    }
    void swapImaget4()
    {
        swapImage(t4);
    }
    void swapImaget5()
    {
        swapImage(t5);
    }
    void swapImaget6()
    {
        swapImage(t6);
    }
    void swapImaget7()
    {
        swapImage(t7);
    }
    void swapImaget8()
    {
        swapImage(t8);
    }

    void swapImage(Button but)
    {
        TD.isOn = false;
        if (but.image.sprite == blankSprite)
        {
            audioSources[0].Play();
            but.image.sprite = hatchSprite;
        }
        else if (but.image.sprite == hatchSprite)
        {
            but.image.sprite = cargoSprite;
        }
        else if (but.image.sprite == cargoSprite)
        {
            audioSources[0].Play();
            but.image.sprite = hatchCargoSprite;
        }
        else if (but.image.sprite == hatchCargoSprite)
        {
            audioSources[1].Play();
            but.image.sprite = blankSprite;
        }
    }

    void loadAllData()
    {
        Variables.roundData = Variables.roundData + Variables.ToBinary(Variables.lowCargoCount, 4);
        Variables.roundData = Variables.roundData + Variables.ToBinary(Variables.lowHatchCount, 4);
        Variables.roundData = Variables.roundData + Variables.ToBinary(Variables.midCargoCount, 3);
        Variables.roundData = Variables.roundData + Variables.ToBinary(Variables.midHatchCount, 3);
        Variables.roundData = Variables.roundData + Variables.ToBinary(Variables.highCargoCount, 3);
        Variables.roundData = Variables.roundData + Variables.ToBinary(Variables.highHatchCount, 3);
        Variables.roundData = Variables.roundData + Variables.ToBinary(Variables.defenseTime, 8);
        Variables.roundData = Variables.roundData + Variables.ToBinary(numberOfErrors, 4);
        Variables.roundData = Variables.roundData + Variables.ToBinary(numberOfFouls, 4);
        if (bricked.isOn)
            Variables.roundData = Variables.roundData + "1";
        else
            Variables.roundData = Variables.roundData + "0";
    }

    void Update()
    {
        //Sound Effects
        if (bricked.isOn && !playedBrickedSound)
        {
            audioSources[2].Play();
            playedBrickedSound = true;
        }
        else if (!bricked.isOn)
            playedBrickedSound = false;

        if (TD.isOn && !playedDefenseSound)
        {
            audioSources[3].Play();
            playedDefenseSound = true;
        }
        else if (!TD.isOn)
            playedDefenseSound = false;

        //Everything else
        errorButton.GetComponentInChildren<Text>().text = "" + numberOfErrors;
        foulButton.GetComponentInChildren<Text>().text = "" + numberOfFouls;
        highrocketHatchCount.text = "" + highrocketHatchCT;
        highrocketCargoCount.text = "" + highrocketCargoCT;
        midrocketHatchCount.text = "" + midrocketHatchCT;
        midrocketCargoCount.text = "" + midrocketCargoCT;
        lowrocketHatchCount.text = "" + lowrocketHatchCT;
        lowrocketCargoCount.text = "" + lowrocketCargoCT;
        if (TD.isOn)
        {
            stopwatch.Start();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
               stopwatch.Elapsed.Hours, stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds,
               stopwatch.Elapsed.Milliseconds / 10);
            TD.GetComponentInChildren<Text>().text = elapsedTime;
        }
        else
        {
            stopwatch.Stop();
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
               stopwatch.Elapsed.Hours, stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds,
               stopwatch.Elapsed.Milliseconds / 10);
            TD.GetComponentInChildren<Text>().text = elapsedTime;
        }

        //doubletap for errorbutton and foulbutton
        if (doubleTapStopwatch.Elapsed.Milliseconds > 200)
        {
            doubleTapStopwatch.Stop();
            doubleTapStopwatch.Reset();
        }
    }


    void loadDefenseCount()
    {
        stopwatch.Stop();
        int time = stopwatch.Elapsed.Minutes * 60 + stopwatch.Elapsed.Seconds;
        stopwatch.Reset();
        Variables.defenseTime = time;

    }

    void loadLowCargoShipCount()
    {
        addLowCountsHelper(t1);
        addLowCountsHelper(t2);
        addLowCountsHelper(t3);
        addLowCountsHelper(t4);
        addLowCountsHelper(t5);
        addLowCountsHelper(t6);
        addLowCountsHelper(t7);
        addLowCountsHelper(t8);
    }

    void addLowCountsHelper(Button but)
    {
        if (but.image.sprite == hatchCargoSprite)
        {
            Variables.lowHatchCount++;
            Variables.lowCargoCount++;
        }
        else if (but.image.sprite == cargoSprite)
        {
            Variables.lowCargoCount++;
        }
        else if (but.image.sprite == hatchSprite)
        {
            Variables.lowHatchCount++;
        }
    }
    void loadNextScene()
    {
        SceneManager.LoadScene(Variables.sceneIdentifier() + "PostRound");
    }
}
