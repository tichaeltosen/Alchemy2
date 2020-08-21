﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEventManager : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction PotionCreate;

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
        RaycastManager.instance.itemNameText.text = "Creating Potion...";
       // Debug.Log("creating potion");
        GameManager.instance.count = 0;
        yield return new WaitForSeconds(1);
        RaycastManager.instance.itemNameText.text = "Potion Created!";
       // Debug.Log("potion created");
        yield return new WaitForSeconds(1);
        if (PotionCreate != null)
        {
            PotionCreate();
        }
        //  Debug.Log("process over");
        yield return new WaitForSeconds(3);
        for(int i = 0; i < RaycastManager.instance.chosenElements.Count; i++)
        {
            RaycastManager.instance.chosenElements.RemoveAt(i);
        }
        RaycastManager.instance.creatingPotion = false;

    }
}



