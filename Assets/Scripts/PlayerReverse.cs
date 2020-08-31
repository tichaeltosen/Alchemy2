using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReverse : MonoBehaviour
{
    public static PlayerReverse instance;
    public PlayerMovement pMovement;

    private float effectTime;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        effectTime = PotionEffects.instance.effectTime;

    }

    public void ReversePlayer()
    {
        if (!RaycastManager.instance.isPotionObject)
        {
            StartCoroutine(ReverseCo());
        }
        UsePotion.Effect -= ReversePlayer;

    }

    private IEnumerator ReverseCo()
    {
        PotionEffects.instance.time = 0;
        PotionEffects.instance.potionEffectActive = true;
        pMovement.Reverse();
        PotionEffects.instance.DrunkChorusOn();

        while (PotionEffects.instance.time != effectTime)
        {
            PotionEffects.instance.TimeCount();
            yield return new WaitForSeconds(1);
            if (PotionEffects.instance.breakRoutine || PotionEffects.instance.time == effectTime)
            {
                pMovement.Normal();
                PotionEffects.instance.potionEffectActive = false;
                PotionEffects.instance.breakRoutine = false;
                FMODUnity.RuntimeManager.PlayOneShot("event:/Potions/End Potion");
                PotionEffects.instance.DrunkChorusOff();


                yield break;
            }
        }

    }

}
