using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    private string potionReturn;
    GameObject moonEffect;
    public float potionTime = 20f;

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
        StartCoroutine(Display());
        
    }

    private IEnumerator Display()
    {
        moonEffect = GameObject.FindGameObjectWithTag("MoonEffect");
        moonEffect.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(2);
        Debug.Log("Turn Off Moon Effect");
        yield return new WaitForSeconds(2);

        moonEffect.GetComponent<SpriteRenderer>().enabled = false;
        UsePotion.Effect -= MoonEffect;


    }

}
