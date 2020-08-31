using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShrink : MonoBehaviour
{
    public static PlayerShrink instance;

    public GameObject pHeight;
    public float fadeTime = 2f;
    public float lerpNumber = 0f;
    public float shrinkHeight = 0.1f;


    private Vector3 startingHeight;
    private float effectTime;
    Vector3 playerHeight;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        startingHeight = new Vector3(pHeight.transform.localScale.x, pHeight.transform.localScale.y, pHeight.transform.localScale.z);
        effectTime = PotionEffects.instance.effectTime;
    }

    public void Shrinking()
    {
        if (!RaycastManager.instance.isPotionObject)
        {
            StartCoroutine(Shrink());
        }
        UsePotion.Effect -= Shrinking;

    }

    private IEnumerator Shrink()
    {
        PotionEffects.instance.time = 0;
        PotionEffects.instance.potionEffectActive = true;
        FMODUnity.RuntimeManager.PlayOneShot("event:/Potions/Shrink");


        for (float t = 0.01f; t < fadeTime; t += 0.1f)
        {
            lerpNumber = Mathf.Lerp(startingHeight.y, shrinkHeight, t / fadeTime);
            pHeight.transform.localScale = new Vector3(startingHeight.x, lerpNumber, startingHeight.z);
            yield return null;
        }

        while (PotionEffects.instance.time != effectTime)
        {
            PotionEffects.instance.TimeCount();
            yield return new WaitForSeconds(1);
            if (PotionEffects.instance.breakRoutine || PotionEffects.instance.time == effectTime)
            {
                StartCoroutine(Grow());
                PotionEffects.instance.potionEffectActive = false;
                PotionEffects.instance.breakRoutine = false;
                FMODUnity.RuntimeManager.PlayOneShot("event:/Potions/End Potion");
                yield break;
            }
        }


    }

    private IEnumerator Grow()
    {
        for (float t = 0.01f; t < fadeTime; t += 0.1f)
        {
            lerpNumber = Mathf.Lerp(shrinkHeight, startingHeight.y, t / fadeTime);
            pHeight.transform.localScale = new Vector3(startingHeight.x, lerpNumber, startingHeight.z);
            yield return null;

        }
    }
}
