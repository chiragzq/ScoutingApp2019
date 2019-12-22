using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    private Camera cam;
    private Vector2 targetResolution = new Vector2(1334,750); //the resolution the game is designed for
    private int ppu=1;

    void Awake()
    {

        cam = GetComponent<Camera>();

        float targetAspect = targetResolution.x / targetResolution.y;
        float currentAspect = Screen.width / (float)Screen.height;

        if (currentAspect < targetAspect)
        {

            float scalingWidth = Screen.width / targetResolution.x;

            float camSize = ((Screen.height / 2) / scalingWidth) / ppu;
            cam.orthographicSize = camSize;
        }
    }

}
