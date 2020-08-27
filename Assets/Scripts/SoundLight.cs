using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLight : MonoBehaviour
{
    public static SoundLight instance;

    private void Awake()
    {
        instance = this;
    }

    public void SoundLightOn()
    {
        gameObject.SetActive(true);
    }

    public void SoundLightOff()
    {
        gameObject.SetActive(false);
    }
}
