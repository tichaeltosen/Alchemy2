using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloat : MonoBehaviour
{
    public static PlayerFloat instance;
    public PlayerMovement pMove;

    private float effectTime;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        effectTime = PotionEffects.instance.effectTime;

    }


    public void Feather()
    {
        if(ItemProperties.instance.itemName != "Quill" && !RaycastManager.instance.isPotionObject)
        {
            StartCoroutine(Floating());
        }
        UsePotion.Effect -= Feather;


    }

    private IEnumerator Floating()
    {
        PotionEffects.instance.time = 0;
        PotionEffects.instance.potionEffectActive = true;
        pMove.Float();
        FMODUnity.RuntimeManager.PlayOneShot("event:/Potions/Float");


        while (PotionEffects.instance.time != effectTime)
        {
            PotionEffects.instance.TimeCount();
            yield return new WaitForSeconds(1);
            if (PotionEffects.instance.breakRoutine || PotionEffects.instance.time == effectTime)
            {
                pMove.Fall();
                PotionEffects.instance.potionEffectActive = false;
                PotionEffects.instance.breakRoutine = false;
                FMODUnity.RuntimeManager.PlayOneShot("event:/Potions/End Potion");
                FMODUnity.RuntimeManager.PlayOneShot("event:/Potions/Fall");


                yield break;
            }
        }

    }
}
