﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEffects : MonoBehaviour
{
    public GameObject moonEffect, sunEffect, fertilityEffect, charGlow;
    public float effectTime = 30;
    public static PotionEffects instance;
    [HideInInspector]
    public bool breakRoutine;
    [HideInInspector]
    public bool potionEffectActive;
    [HideInInspector]
    public int time = 0;

    [FMODUnity.EventRef]
    public string fmodEvent;

    private float startingHeight;

    FMOD.Studio.EventInstance PotionMusic;

    [SerializeField]
    [Range(0f, 1f)]
    private float volume;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PotionMusic = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        PotionMusic.start();
        PotionMusic.setParameterByName("Light", 0f);
        PotionMusic.setParameterByName("Dark", 0f);
        PotionMusic.setParameterByName("Ritual", 0f);


    }



    public void TimeCount()
    {
        time += 1;
    }

    public void Update()
    {
        //PotionMusic.setParameterByName("Ritual", volume);
        if (!potionEffectActive)
        {
            PotionMusic.setParameterByName("PVolume", 0f);
        }

    }

    public void Moon()
    {
        if (!RaycastManager.instance.isPotionObject)
        {
            StartCoroutine(Reveal(moonEffect));
        }

        UsePotion.Effect -= Moon;
    }

    public void Sun()
    {
        if (!RaycastManager.instance.isPotionObject)
        {
           StartCoroutine(Reveal(sunEffect));
        }
        UsePotion.Effect -= Sun;

    }


    public void Fertility()
    {
        if (!RaycastManager.instance.isPotionObject)
        {
            StartCoroutine(Reveal(fertilityEffect));
            StartCoroutine(Reveal(charGlow));

        }
        UsePotion.Effect -= Fertility;
    }

    


    // ....... for sun / moon / fertility-action1 ............................
    private IEnumerator Reveal(GameObject pEffect)
    {
        time = 0;
        potionEffectActive = true;
        pEffect.SetActive(true);
        while(time != effectTime)
        {
            TimeCount();
            yield return new WaitForSeconds(1);
            if (breakRoutine || time == effectTime)
            {
                potionEffectActive = false;
                pEffect.SetActive(false);
                breakRoutine = false;
                FMODUnity.RuntimeManager.PlayOneShot("event:/Potions/End Potion");

                yield break;
            }
        }

       

    }

    public void StartPotionMusic()
    {
        PotionMusic.setParameterByName("PVolume", 1f);

    }

    public void StartRitualMusic()
    {
        PotionMusic.setParameterByName("Ritual", 1f);

    }

    public void StartDarkMusic()
    {
        PotionMusic.setParameterByName("Dark", 1f);

    }
    public void StartLightMusic()
    {
        PotionMusic.setParameterByName("Light", 1f);

    }

    public void DrunkChorusOn()
    {
        PotionMusic.setParameterByName("Drunk", 1f);

    }

    public void DrunkChorusOff()
    {
        PotionMusic.setParameterByName("Drunk", 0f);

    }

}
