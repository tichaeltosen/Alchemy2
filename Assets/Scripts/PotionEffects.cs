using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEffects : MonoBehaviour
{
    public GameObject moonEffect, sunEffect, fertilityEffect;
    public float effectTime = 30;
    public static PotionEffects instance;
    [HideInInspector]
    public bool breakRoutine;
    [HideInInspector]
    public bool potionEffectActive;
    [HideInInspector]
    public int time = 0;


    private float startingHeight;


    private void Awake()
    {
        instance = this;
    }

    public void TimeCount()
    {
        time += 1;
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
            Debug.Log("Time" + time);
            if (breakRoutine || time == effectTime)
            {
                potionEffectActive = false;
                pEffect.SetActive(false);
                breakRoutine = false;
                yield break;
            }
        }

       

    }

}
