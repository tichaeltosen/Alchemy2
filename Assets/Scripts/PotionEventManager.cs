using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEventManager : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction PotionCreate, PotionInstantiate;
    public string potionReturn;
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

        potionReturn = CraftRecipe.instance.CraftedPotion();
     
        yield return new WaitForSeconds(1);
        if (PotionInstantiate != null)
        {
            PotionInstantiate();
        }
        //check if potion returns something
        if (potionReturn != "None")
        {
            potionEquipped = true;
        }
        yield return new WaitForSeconds(2);

        for (int i = 0; i < RaycastManager.instance.chosenElements.Count; i++)
        {
            RaycastManager.instance.chosenElements.RemoveAt(i);
        }
        RaycastManager.instance.creatingPotion = false;

    }
}



