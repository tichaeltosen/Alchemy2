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
            Destroy(gameObject);
            if(Effect != null)
            {
                Effect();

            }

        }
    }

    private void OnDestroy()
    {
        Debug.Log("Destroyed");
    }
}
