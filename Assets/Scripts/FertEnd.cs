﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FertEnd : MonoBehaviour
{
    public static FertEnd instance;
    private float effectTime;


    private void Awake()
    {
        instance = this;
    }

    public void LightEnd()
    {
        if (!RaycastManager.instance.isPotionObject && GameManager.instance.sulfurState)
        {
            StartCoroutine(Fertility());
        }
        UsePotion.Effect -= LightEnd;

    }

    private IEnumerator Fertility()
    {
        PotionEffects.instance.time = 0;
        PotionEffects.instance.potionEffectActive = true;

        while (PotionEffects.instance.time != effectTime)
        {
            PotionEffects.instance.TimeCount();
            yield return new WaitForSeconds(1);
            Debug.Log("Time" + PotionEffects.instance.time);
            if (GameManager.instance.circleStatus)
            {
                //Trigger the Light Ending


            }
            if (PotionEffects.instance.breakRoutine || PotionEffects.instance.time == effectTime)
            {
                PotionEffects.instance.potionEffectActive = false;
                PotionEffects.instance.breakRoutine = false;
                yield break;
            }
        }

    }


}