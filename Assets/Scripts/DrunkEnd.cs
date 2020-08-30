using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkEnd : MonoBehaviour
{
    public static DrunkEnd instance;
    private float effectTime;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        effectTime = PotionEffects.instance.effectTime;

    }
    public void DrunkEnding()
    {
        if (!RaycastManager.instance.isPotionObject && GameManager.instance.sulfurState)
        {
            StartCoroutine(DrunkCo());
        }
        UsePotion.Effect -= DrunkEnding;

    }

    private IEnumerator DrunkCo()
    {
        PotionEffects.instance.time = 0;
        PotionEffects.instance.potionEffectActive = true;

        while (PotionEffects.instance.time != effectTime)
        {

            PotionEffects.instance.TimeCount();
            yield return new WaitForSeconds(1);

            if (GameManager.instance.circleStatus)
            {
                //Trigger the Light Ending
                ExitDoor.instance.DarkExit();
                PartDark.instance.DarkEndParticle();
                PotionEffects.instance.StartDarkMusic();

                yield break;

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
