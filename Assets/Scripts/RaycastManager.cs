﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastManager : MonoBehaviour
{
    public static RaycastManager instance;
    public Text itemNameText;
    public bool creatingPotion;
    public List<string> chosenElements = new List<string>();


    private GameObject raycastedObj;

    [Header("Raycast Settings")]
    [SerializeField]
    private float rayLength = 3;
    [SerializeField]
    private LayerMask newLayerMask;

    [Header("References")]
    [SerializeField]
    private Image crossHair;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (!PotionEventManager.instance.potionEquipped)
        {
            PotionDisabled();
        }else if (PotionEventManager.instance.potionEquipped)
        {

        }
    }

    void CrosshairActive()
    {
        crossHair.enabled = true;
        crossHair.color = Color.red;
    }

    void CrosshairNormal()
    {
        crossHair.enabled = true;
        crossHair.color = Color.white;
    }

    void CrossHairDisabled()
    {
        crossHair.enabled = false;
    }

    void PotionDisabled()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, newLayerMask.value))
        {
            if (hit.collider.CompareTag("Element") && GameManager.instance.count < 2)
            {
                CrosshairActive();
                raycastedObj = hit.collider.gameObject;
                itemNameText.text = raycastedObj.GetComponent<ItemProperties>().itemName;
                //update UI Name, etc. below
                if (Input.GetMouseButtonDown(0))
                {
                    // do something
                    raycastedObj.GetComponent<ItemProperties>().Interaction();
                    // add to list of chosen elements
                    chosenElements.Add(raycastedObj.name);

                }
            }
            else if (hit.collider.CompareTag("MakePotion"))
            {
                CrosshairActive();
                raycastedObj = hit.collider.gameObject;

                if (GameManager.instance.count < 2 && !creatingPotion)
                {
                    itemNameText.text = "Choose Elements To Create Potion";

                }
                else if (GameManager.instance.count == 2 && !creatingPotion)
                {
                    itemNameText.text = "Click To Create Potion";

                }
                if (Input.GetMouseButtonDown(0))
                {
                    raycastedObj.GetComponent<PotionEventManager>().CreatingPotion();
                }

            }
        }
        else
        {
            CrosshairNormal();
            if (!creatingPotion)
            {
                itemNameText.text = "";
            }
        }

    }

    void PotionEnabled()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, newLayerMask.value))
        {
            if (hit.collider.CompareTag("Potion-Interactable"))
            {
                CrossHairDisabled();
                raycastedObj = hit.collider.gameObject;
                itemNameText.text = raycastedObj.GetComponent<ItemProperties>().itemName;
                //update UI Name, etc. below
                if (Input.GetMouseButtonDown(0))
                {
                    // do something
                    raycastedObj.GetComponent<ItemProperties>().Interaction();

                }
            }

}
