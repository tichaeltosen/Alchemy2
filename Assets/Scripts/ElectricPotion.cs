using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPotion : MonoBehaviour
{
    public static ElectricPotion instance;
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


    public void ElectricChest()
    {
        if (!RaycastManager.instance.isPotionObject)
        {
            StartCoroutine(ElectricChestCo());
        }
        UsePotion.Effect -= ElectricChest;


    }

    private IEnumerator ElectricChestCo()
    {
        PotionEffects.instance.time = 0;
        PotionEffects.instance.potionEffectActive = true;
        chestStatus.isLocked = false;
        PartElectric.instance.ElectricParticle();

        while (PotionEffects.instance.time != effectTime)
        {
            PotionEffects.instance.TimeCount();
            yield return new WaitForSeconds(1);
            if (PotionEffects.instance.breakRoutine || PotionEffects.instance.time == effectTime)
            {
                chestStatus.isLocked = true;
                PotionEffects.instance.potionEffectActive = false;
                PotionEffects.instance.breakRoutine = false;
                yield break;
            }
        }

    }
}
