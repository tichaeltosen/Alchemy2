﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    public int framesPerSecond = 30; 
    // Start is called before the first frame update
    void Start()
    {
        {
            QualitySettings.vSyncCount = 0;  // VSync must be disabled
            Application.targetFrameRate = framesPerSecond;
        }
    }


}
