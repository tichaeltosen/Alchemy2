using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHide : ElementData
{
    GameObject[] variants;
    //list of elements on potion table
    [HideInInspector]
    public bool rackStatus;

    private void Start()
    {
         PotionEventManager.PotionCreate += ShowObject;

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

        if (gameObject.CompareTag("Element"))
        {
            PotionEventManager.PotionCreate -= ShowObject;
        }

    }


    public void ShowObject()
    {
        IElement Rack = gameObject.GetComponent<IElement>();
        if (gameObject.GetComponent<IElement>() != null)
        {
            rackStatus = Rack.IsRacked();
        }

        if (rackStatus)
        {
            gameObject.SetActive(true);

        }

        variants = GameObject.FindGameObjectsWithTag("Variant");
        foreach(GameObject variant in variants)
        {
            Destroy(variant);
        }
    }


}
