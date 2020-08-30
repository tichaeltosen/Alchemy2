using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEventManager : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction PotionCreate, PotionInstantiate;
    [HideInInspector]
    public string potionReturn;
    [HideInInspector]
    public bool potionEquipped; 
    public static PotionEventManager instance;

    public void Awake()
    {
        instance = this;
    }

    public void CreatingPotion()
    {
        if (GameManager.instance.count == 2 && !RaycastManager.instance.creatingPotion)
        {
            RaycastManager.instance.creatingPotion = true;
            RaycastManager.instance.itemNameText.text = "Create Potion";
            StartCoroutine(WaitForPotion());

        }
    }

    private IEnumerator WaitForPotion()
    {
        // make the potion...
        GameManager.instance.count = 0;
      
        if (PotionCreate != null)
        {
            PotionCreate();

        }

        FMODUnity.RuntimeManager.PlayOneShot("event:/Potions/Potion Create");
        RaycastManager.instance.itemNameText.text = "Mixing the ingredients...";


        potionReturn = CraftRecipe.instance.CraftedPotion();
          
        yield return new WaitForSeconds(2);
        if (potionReturn != "None")
        {
            RaycastManager.instance.itemNameText.text = "Your potion is:  " + CraftRecipe.instance.potion;

        }else
        {
            RaycastManager.instance.itemNameText.text = "These ingredients do not work together!";
        }

        yield return new WaitForSeconds(2);
        if (PotionInstantiate != null)
        {
            PotionInstantiate();
        }
        //check if potion returns something
        if (potionReturn != "None")
        {
            potionEquipped = true;
            Debug.Log("Potion Equipped!");
        }

        RaycastManager.instance.chosenElements.RemoveAt(1);
        RaycastManager.instance.chosenElements.RemoveAt(0);
        RaycastManager.instance.creatingPotion = false;

    }
}



