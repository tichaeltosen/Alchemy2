using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthPotion : MonoBehaviour
{
    public static StrengthPotion instance;
    public ChestStatus chestStatus;

    private float effectTime;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        effectTime = PotionEffects.instance.effectTime;

    }


    public void StrengthChest()
    {
        if (!RaycastManager.instance.isPotionObject)
        {
           StartCoroutine(StrengthChestCo());
        }
        UsePotion.Effect -= StrengthChest;


    }

    private IEnumerator StrengthChestCo()
    {
        PotionEffects.instance.time = 0;
        PotionEffects.instance.potionEffectActive = true;
        chestStatus.isLocked = false;
        Debug.Log(gameObject.name + " " + chestStatus.isLocked);


        while (PotionEffects.instance.time != effectTime)
        {
            PotionEffects.instance.TimeCount();
            yield return new WaitForSeconds(1);
            if (PotionEffects.instance.breakRoutine || PotionEffects.instance.time == effectTime)
            {
                Debug.Log("Strength Broken");
                chestStatus.isLocked = true;
                PotionEffects.instance.potionEffectActive = false;
                PotionEffects.instance.breakRoutine = false;
                FMODUnity.RuntimeManager.PlayOneShot("event:/Potions/End Potion");
                yield break;
            }
        }

    }

    public void ForceOff()
    {
        Debug.Log("Strength Broken");
        chestStatus.isLocked = true;
        PotionEffects.instance.potionEffectActive = false;
        PotionEffects.instance.breakRoutine = false;
    }
}
