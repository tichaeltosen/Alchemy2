using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    private string potionReturn;
    GameObject moonEffect;

    private void OnEnable()
    {

        potionReturn = CraftRecipe.instance.CraftedPotion();
        if (potionReturn == "Moon")
        {
            UsePotion.Effect += MoonEffect;
        }
    }


    public void MoonEffect()
    {
        Debug.Log("Moon Effect Starting");
        moonEffect = GameObject.FindGameObjectWithTag("MoonEffect");
        moonEffect.GetComponent<SpriteRenderer>().enabled = true;
        UsePotion.Effect -= MoonEffect;
        Debug.Log("Moon Effect Complete!");
    }

}
