using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPotion : MonoBehaviour
{
    public static SoundPotion instance;
    public GameObject lead, fire;

    private float effectTime;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        effectTime = PotionEffects.instance.effectTime;

    }


    public void SoundPo()
    {
        if (!RaycastManager.instance.isPotionObject)
        {
            StartCoroutine(SoundCo());
        }
        UsePotion.Effect -= SoundPo;


    }

    private IEnumerator SoundCo()
    {
        PotionEffects.instance.time = 0;
        PotionEffects.instance.potionEffectActive = true;
        lead.SetActive(true);
        fire.SetActive(true);

        while (PotionEffects.instance.time != effectTime)
        {
            PotionEffects.instance.TimeCount();
            yield return new WaitForSeconds(1);
            if (PotionEffects.instance.breakRoutine || PotionEffects.instance.time == effectTime)
            {
                lead.SetActive(false);
                fire.SetActive(false);
                PotionEffects.instance.potionEffectActive = false;
                PotionEffects.instance.breakRoutine = false;
                yield break;
            }
        }

    }
}
