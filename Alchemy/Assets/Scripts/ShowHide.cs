using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHide : MonoBehaviour
{
    GameObject[] variants;
    //list of elements on potion table
    bool wasActive;

    private void OnDisable()
    {
        if (gameObject.CompareTag("Element"))
        {
            PotionEventManager.PotionCreate += ShowObject;
            //add to chosen element list
            ChosenElement.instance.chosenEl.Add(gameObject.name);
            
        }
    }

    private void OnEnable()
    {
        wasActive = gameObject.GetComponent<ElementData>().FindElement(gameObject.name);

        Debug.Log("test:" + gameObject.GetComponent<ElementData>().elementList.Count);

        if(gameObject.CompareTag("Element") )
        {
            PotionEventManager.PotionCreate -= ShowObject;
            //remove from chosen element list
           // ChosenElement.instance.chosenEl.Remove(gameObject.name);
        }
        else if (gameObject.CompareTag("Element"))
        {
            ElementData.instance.elementList.Add(gameObject.name);
            // check to make sure active element list grows 
            Debug.Log("Active Elements:" + ElementData.instance.elementList.Count);
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
