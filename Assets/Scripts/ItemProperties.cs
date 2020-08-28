using System.Collections;
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


    private void Awake()
    {
        instance = this;
    }

    public void Interaction()
    {

        IElement RackStatus = gameObject.GetComponent<IElement>();
        IChest LockedStatus = gameObject.GetComponent<IChest>();

        if (gameObject.GetComponent<IElement>() != null)
        {
           rStatus = RackStatus.IsRacked();

        }

        if (gameObject.GetComponent<IChest>() != null)
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
                EndState.instance.ShowThird();
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

            if (itemName == "Quill" && potion == "Heavy")
            {
                UsePotion.Effect += HiddenDoor.instance.ShowDoor;
                UsePotion.Effect += BalanceScale.instance.Balance;
            }else if(itemName == "Skull" && potion == "Feather")
            {
                UsePotion.Effect += HiddenDoor.instance.ShowDoor;
                UsePotion.Effect += BalanceScale.instance.Balance;
            }
            else
            {
                //trigger default pouring sound and maybe "potion doesn't work on this object
            }


        }

        else if (endPotion)
        {
            if(PotionEffects.instance.potionEffectActive)
            {
                PotionEffects.instance.breakRoutine = true;
            }

        }
        //...............Chest....................
        else if (chest && lStatus)
        {
            if (itemName == "Strength Chest")
            {
                RaycastManager.instance.itemNameText.text = "The lid is stuck. If only you were a little stronger...";

            }else if(itemName == "Unlocked")
            {
                gameObject.GetComponent<OpenChest>().Open();

            }else if(itemName == "Electric Chest")
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
