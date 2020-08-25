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
        StartCoroutine(pSlow());
        UsePotion.Effect -= Slow;


    }

    private IEnumerator pSlow()
    {
        PotionEffects.instance.time = 0;
        PotionEffects.instance.potionEffectActive = true;
        playerMove.speed = slowSpeed;

        while (PotionEffects.instance.time != 30)
        {
            PotionEffects.instance.TimeCount();
            yield return new WaitForSeconds(1);
            Debug.Log("Time" + PotionEffects.instance.time);
            if (PotionEffects.instance.breakRoutine || PotionEffects.instance.time == effectTime)
            {
                playerMove.speed = normalSpeed;
                PotionEffects.instance.potionEffectActive = false;
                PotionEffects.instance.breakRoutine = false;
                yield break;
            }
        }

    }


}
