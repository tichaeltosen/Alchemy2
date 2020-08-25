using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShrink : MonoBehaviour
{
    public static PlayerShrink instance;

    public CharacterController cControl;
    public float fadeTime = 2f;
    public float lerpNumber = 0f;
    public float shrinkHeight = 2f;

    private float startingHeight;
    private float effectTime;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        startingHeight = cControl.height;
        effectTime = PotionEffects.instance.effectTime;
    }

    public void Shrinking()
    {
        StartCoroutine(Shrink());
        Debug.Log("Shrinking Activated");
        UsePotion.Effect -= Shrinking;

    }

    private IEnumerator Shrink()
    {
        PotionEffects.instance.time = 0;
        PotionEffects.instance.potionEffectActive = true;

        for (float t = 0.01f; t < fadeTime; t += 0.1f)
        {
            lerpNumber = Mathf.Lerp(startingHeight, shrinkHeight, t / fadeTime);
            cControl.height = lerpNumber;
            yield return null;
        }

        while (PotionEffects.instance.time != 30)
        {
            PotionEffects.instance.TimeCount();
            yield return new WaitForSeconds(1);
            Debug.Log("Time" + PotionEffects.instance.time);
            if (PotionEffects.instance.breakRoutine || PotionEffects.instance.time == effectTime)
            {
                StartCoroutine(Grow());
                PotionEffects.instance.potionEffectActive = false;
                PotionEffects.instance.breakRoutine = false;
                yield break;
            }
        }


    }

    private IEnumerator Grow()
    {
        for (float t = 0.01f; t < fadeTime; t += 0.1f)
        {
            lerpNumber = Mathf.Lerp(shrinkHeight, startingHeight, t / fadeTime);
            cControl.height = lerpNumber;
            yield return null;

        }
    }
}
