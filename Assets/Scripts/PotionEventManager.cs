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
        yield return new WaitForSeconds(1);

        RaycastManager.instance.chosenElements.RemoveAt(1);
        RaycastManager.instance.chosenElements.RemoveAt(0);


        yield return new WaitForSeconds(2);

        RaycastManager.instance.creatingPotion = false;

    }
}



