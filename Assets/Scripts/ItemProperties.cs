using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemProperties : MonoBehaviour
{

    [Header("Item Type")]
    public string itemName;
    public GameObject chosenElement;
    public GameObject potionTable1;
    public GameObject potionTable2;


    [SerializeField]
    private bool element;
    [SerializeField]
    private bool potion_interactable;
    [SerializeField]
    private bool book;
    private bool rStatus;



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
            //

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
