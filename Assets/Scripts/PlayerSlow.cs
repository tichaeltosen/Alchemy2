using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlow : MonoBehaviour
{
    public static PlayerSlow instance;
    public PlayerMovement playerMove;
    public float slowSpeed = 4;

    private float normalSpeed;

    private float effectTime;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        effectTime = PotionEffects.instance.effectTime;
        normalSpeed = playerMove.speed;


    }

    public void Slow()
    {
        if (ItemProperties.instance.itemName != "Skull" && !RaycastManager.instance.isPotionObject)
        {
            StartCoroutine(pSlow());
        }
        UsePotion.Effect -= Slow;

    }

    private IEnumerator pSlow()
    {
        PotionEffects.instance.time = 0;
        PotionEffects.instance.potionEffectActive = true;
        playerMove.speed = slowSpeed;

        while (PotionEffects.instance.time != effectTime)
        {
            PotionEffects.instance.TimeCount();
            yield return new WaitForSeconds(1);
            if (PotionEffects.instance.breakRoutine || PotionEffects.instance.time == effectTime)
            {
                playerMove.speed = normalSpeed;
                PotionEffects.instance.potionEffectActive = false;
                PotionEffects.instance.breakRoutine = false;
                FMODUnity.RuntimeManager.PlayOneShot("event:/Potions/End Potion");

                yield break;
            }
        }

    }


}
