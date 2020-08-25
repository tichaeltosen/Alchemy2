using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemProperties : MonoBehaviour
{
    public static ItemProperties instance;

    [Header("Item Type")]
    public string itemName;
    public GameObject chosenElement;
    public GameObject potionTable1;
    public GameObject potionTable2;
    public bool scaleBalanced;


    [SerializeField]
    private bool element;
    [SerializeField]
    private bool potion_interactable;
    [SerializeField]
    private bool book;
    [SerializeField]
    private bool endPotion;
    private string potion;
    private bool rStatus;


    private void Awake()
    {
        instance = this;
    }

    public void Interaction()
    {

        IElement RackStatus = gameObject.GetComponent<IElement>();
        if (gameObject.GetComponent<IElement>() != null)
        {
           rStatus = RackStatus.IsRacked();

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

        }

        else if (potion_interactable)
        {
            potion = PotionEventManager.instance.potionReturn;

            if (itemName == "Quill" && potion == "Feather")
            {
                UsePotion.Effect += PlayerFloat.instance.Feather;
                scaleBalanced = true;
            }

        }

        else if (endPotion)
        {
            if(PotionEffects.instance.potionEffectActive)
            {
                PotionEffects.instance.breakRoutine = true;
            }

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
