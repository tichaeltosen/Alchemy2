using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePotion : MonoBehaviour
{
    public delegate void PotionEffect();
    public static event PotionEffect Effect;
 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PotionEventManager.instance.potionEquipped = false;
            PotionEffects.instance.breakRoutine = false;
            if(Effect != null)
            {
                Effect();
                PotEndParticle.instance.PotionParticle();
            }
            Destroy(gameObject);


        }
    }

}
