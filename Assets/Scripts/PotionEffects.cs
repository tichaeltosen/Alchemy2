using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEffects : MonoBehaviour
{
    public GameObject moonEffect, sunEffect, player, fertilityEffect;
    public float effectTime = 30;
    public static PotionEffects instance;
    public bool breakRoutine;
    public bool potionEffectActive;
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
        StartCoroutine(Reveal(moonEffect));

        UsePotion.Effect -= Moon;
    }

    public void Sun()
    {
        StartCoroutine(Reveal(sunEffect));
        UsePotion.Effect -= Sun;

    }

 

    public void Strength()
    {
        UsePotion.Effect -= Strength;

    }

    public void Feather()
    {
        UsePotion.Effect -= Feather;

    }

    public void Electric()
    {
        UsePotion.Effect -= Electric;

    }

    public void Heavy()
    {
        UsePotion.Effect -= Heavy;

    }

    public void Sound()
    {
        UsePotion.Effect -= Sound;

    }


    public void Fertility()
    {
        StartCoroutine(Reveal(fertilityEffect));
        UsePotion.Effect -= Sun;
    }




    //.... Shrinking..........................
    


    // ....... for sun / moon / fertility-action1 ............................
    private IEnumerator Reveal(GameObject pEffect)
    {
        time = 0;
        potionEffectActive = true;
        pEffect.SetActive(true);
        while(time != 30)
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
