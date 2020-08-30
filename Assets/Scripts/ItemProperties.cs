﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemProperties : MonoBehaviour
{
    public static ItemProperties instance;

    [Header("Item Type")]
    public string itemName;
    [Header("Element Variant")]
    public GameObject chosenElement;
    [Header("Choose Text")]
    public GameObject textChoice;
    [Header("Variant Positions")]
    public GameObject potionTable1;
    public GameObject potionTable2;

    [Header("Type Of Object")]
    [SerializeField]
    private bool element;
    [SerializeField]
    private bool potionInteractable;
    [SerializeField]
    private bool book;
    [SerializeField]
    private bool endPotion;

    [SerializeField]
    private bool chest;
    [SerializeField]
    private bool text;

    private string potion;
    private bool rStatus;
    private bool lStatus;

    FMOD.Studio.EventInstance ritual;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ritual = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Main Loop");
    }

    public void Interaction()
    {

        IElement RackStatus = gameObject.GetComponent<IElement>();
        IChest LockedStatus = gameObject.GetComponentInParent<IChest>();

        if (gameObject.GetComponent<IElement>() != null)
        {
           rStatus = RackStatus.IsRacked();

        }

        if (gameObject.GetComponentInParent<IChest>() != null)
        {
            lStatus = LockedStatus.IsLocked();

        }

        // if it's an element on the spice rack
        if (element && rStatus)
        {
            if (GameManager.instance.count == 0)
            {
                PlaceElement(potionTable1);
            }
            else if(GameManager.instance.count == 1)
            {
                PlaceElement(potionTable2);

            }
        }
        // if it's an element but not on the rack yet
        else if(element && !rStatus && gameObject.GetComponent<IElement>() != null)
        {
            RackStatus.ChangeRackedStatus();
            RackStatus.MoveElement();
            if(gameObject.name == "Sulfur")
            {
                //
                GameManager.instance.sulfurState = true;
                PotionEffects.instance.StartRitualMusic();
                EndState.instance.ShowThird();
                ritual.setParameterByName("Ritual", 1f);
                FMODUnity.RuntimeManager.PlayOneShot("event:/Interactable/Bell");


            }

            //break potion spell if active when new element found
            if (PotionEffects.instance.potionEffectActive)
            {
                PotionEffects.instance.breakRoutine = true;
            }

        }

        else if (potionInteractable)
        {
            potion = PotionEventManager.instance.potionReturn;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Potions/Potion Pour");


            if (itemName == "Quill" && potion == "Heavy")
            {
                UsePotion.Effect += HiddenDoor.instance.ShowDoor;
                UsePotion.Effect += BalanceScale.instance.Balance;
            }else if(itemName == "Skull" && potion == "Feather")
            {
                UsePotion.Effect += HiddenDoor.instance.ShowDoor;
                UsePotion.Effect += BalanceScale.instance.Balance;
            }
         

        }

        else if (endPotion)
        {
            if(PotionEffects.instance.potionEffectActive)
            {
                PotionEffects.instance.breakRoutine = true;
                FMODUnity.RuntimeManager.PlayOneShot("event:/Potions/Antidote");

            }

        }
        //...............Chest....................
        else if (chest && lStatus)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Interactable/Chest Locked");

            if (itemName == "Strength Chest")
            {
                RaycastManager.instance.itemNameText.text = "The lid is stuck. If only you were a little stronger...";

            }else if(itemName == "Unlocked")
            {
                gameObject.GetComponent<OpenChest>().Open();

            }
            else if(itemName == "Electric Chest")
            {
                RaycastManager.instance.itemNameText.text = "The chest seems to require energy of some sort...";

            }
        }

        else if(chest && !lStatus)
        {
            gameObject.GetComponentInParent<OpenChest>().Open();
            //PotionEffects.instance.potionEffectActive = false;


        }
        else if (text)
        {
            textChoice.SetActive(true);
            GameManager.instance.textState = true;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Interactable/Note Up");

        }

    }

    void PlaceElement(GameObject element)
    {
        gameObject.SetActive(false); 
        GameObject newElement = Instantiate(chosenElement, element.transform.position, element.transform.rotation);
        newElement.name = itemName + "Copy";
        GameManager.instance.count++;

    }

    
}
