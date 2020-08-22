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


    Vector3 scaleChange; // change scale of object clicked on maybe

    public void Start()
    {
     //
    
    }


    public void Interaction()
    {

        if (element)
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
    //    Debug.Log(GameManager.instance.count);

    }

    
}
