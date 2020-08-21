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
            //chosenElements.Add(gameObject.name);
        //    Debug.Log("Chosen Count  :  " + chosenElements.Count);
        }
    }

    private void OnEnable()
    {
        wasActive = FindElement(gameObject.name);

        if(gameObject.CompareTag("Element") && wasActive)
        {
            PotionEventManager.PotionCreate -= ShowObject;
            //if(chosenElements.Count > 0)
            //{
            //    chosenElements.Remove(gameObject.name);
            //}
        
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
