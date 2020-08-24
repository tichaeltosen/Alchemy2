using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEffects : MonoBehaviour
{
    public GameObject moonEffect, sunEffect, player;
    public float effectTime = 30;
    public static PotionEffects instance;
    public bool breakRoutine;
    public bool potionEffectActive;
    public int time = 0;
    public float fadeTime = 2f;
    public float lerpNumber = 0f;
    public float shrinkHeight = 2f;

    private float startingHeight;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        startingHeight = player.GetComponent<CharacterController>().height;
      
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

    public void Shrinking()
    {
        StartCoroutine(Shrink());
        UsePotion.Effect -= Shrinking;

    }




    //.... Shrinking..........................
    private IEnumerator Shrink()
    {
        time = 0;
        potionEffectActive = true;

        for (float t = 0.01f; t < fadeTime; t += 0.1f)
        {
            lerpNumber = Mathf.Lerp(startingHeight, shrinkHeight, t / fadeTime);
            player.GetComponent<CharacterController>().height = lerpNumber;
            yield return null;
        }

        while (time != 30)
        {
            TimeCount();
            yield return new WaitForSeconds(1);
            Debug.Log("Time" + time);
            if (breakRoutine || time == effectTime)
            {
                StartCoroutine(Grow());
                potionEffectActive = false;
                breakRoutine = false;
                yield break;
            }
        }


    }

    private IEnumerator Grow()
    {
        for (float t = 0.01f; t < fadeTime; t += 0.1f)
        {
            lerpNumber = Mathf.Lerp(shrinkHeight, startingHeight, t / fadeTime);
            player.GetComponent<CharacterController>().height = lerpNumber;
            yield return null;

        }
    }


    // ....... for sun and moon ............................
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
