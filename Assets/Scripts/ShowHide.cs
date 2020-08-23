using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHide : ElementData
{
    GameObject[] variants;
    //list of elements on potion table
    bool wasActive;

    private void Start()
    {
    }

    private void OnDisable()
    {
        if (gameObject.CompareTag("Element"))
        {
            PotionEventManager.PotionCreate += ShowObject;
    
        }
    }

    // do this based on if the element was racked or not

    private void OnEnable()
    {
        wasActive = FindElement(gameObject.name);

        if(gameObject.CompareTag("Element") && wasActive)
        {
            PotionEventManager.PotionCreate -= ShowObject;
          
        
        }
        else if (gameObject.CompareTag("Element") && !wasActive)
        {
            elementList.Add(gameObject.name);
            // check to make sure active element list grows 
            Debug.Log("Active Elements:" + elementList.Count);
        }
    }


    public void ShowObject()
    {
        gameObject.SetActive(true);

        variants = GameObject.FindGameObjectsWithTag("Variant");
        foreach(GameObject variant in variants)
        {
            Destroy(variant);
        }
    }


}
