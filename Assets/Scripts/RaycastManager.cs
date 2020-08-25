using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastManager : MonoBehaviour
{
    public static RaycastManager instance;
    public Text itemNameText;
    public bool creatingPotion;
    public List<string> chosenElements = new List<string>();
    public bool isPotionObject;



    private GameObject raycastedObj;
    private GameObject potionObject;

    [Header("Raycast Settings")]
    [SerializeField]
    private float rayLength = 3;
    [SerializeField]
    private LayerMask newLayerMask;

    [Header("References")]
    [SerializeField]
    private Image crossHair;
    private bool rStatus;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

    }

    void Update()
    {
        if (!PotionEventManager.instance.potionEquipped)
        {
            CrosshairNormal();
            PotionDisabled();
            isPotionObject = false;
        }
        else if (PotionEventManager.instance.potionEquipped)
        {
            CrossHairDisabled();
            PotionEnabled();
        }
    }

    void PotionDisabled()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);        

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, newLayerMask.value))
        {
            //.............Select Element...................

            if (hit.collider.CompareTag("Element") && GameManager.instance.count < 2)
            {
                raycastedObj = hit.collider.gameObject;
                IElement RackStatus = raycastedObj.GetComponent<IElement>();
                if (raycastedObj.GetComponent<IElement>() != null)
                {
                    rStatus = RackStatus.IsRacked();
                }
                if (!rStatus)
                {
                    CrosshairActive();
                    itemNameText.text = raycastedObj.GetComponent<ItemProperties>().itemName;
                    if (Input.GetMouseButtonDown(0))
                    {
                        raycastedObj.GetComponent<ItemProperties>().Interaction();

                    }
                }else if (rStatus)
                {
                    CrosshairActive();
                    itemNameText.text = raycastedObj.GetComponent<ItemProperties>().itemName;
                    if (Input.GetMouseButtonDown(0))
                    {

                        raycastedObj.GetComponent<ItemProperties>().Interaction();
                        // add to list of chosen elements
                        chosenElements.Add(raycastedObj.name);
                        Debug.Log("Chosen Element is : " + raycastedObj.name);
                    }
        
                }
            }
            //.............Make Potion...................

            else if (hit.collider.CompareTag("MakePotion"))
            {
                CrosshairActive();
                raycastedObj = hit.collider.gameObject;

                if (!PotionEffects.instance.potionEffectActive)
                {
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
                }else if (PotionEffects.instance.potionEffectActive)
                {
                    itemNameText.text = "Wait For Current Potion To End...";
                }
            }
            else if (hit.collider.CompareTag("End-Potion") && PotionEffects.instance.potionEffectActive)
            {
                CrosshairActive();
                raycastedObj = hit.collider.gameObject;
                itemNameText.text = "Click To End Potion";
                if (Input.GetMouseButtonDown(0))
                {
                    raycastedObj.GetComponent<ItemProperties>().Interaction();

                }

            }
            //.............End Potion...................
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
        itemNameText.text = "";

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, newLayerMask.value))
        {
            //.............Put Potion On Object...................

            if (hit.collider.CompareTag("Potion-Interactable"))
            {
                isPotionObject = true;
                potionObject = GameObject.FindWithTag("Potion");
                Renderer[] renderers = potionObject.GetComponentsInChildren<Renderer>();
                foreach(Renderer r in renderers)
                {
                    Color color = r.material.color;
                    color.a = 0.8f;
                    r.material.color = color;    
                }

                raycastedObj = hit.collider.gameObject;

                itemNameText.text = raycastedObj.GetComponent<ItemProperties>().itemName;

                if (Input.GetMouseButtonDown(0))
                {
                    // do something
                    raycastedObj.GetComponent<ItemProperties>().Interaction();
                }
            }
            
        }
        else
        {
            //.............Nothing...................

            itemNameText.text = "";
            isPotionObject = false;
            potionObject = GameObject.FindWithTag("Potion");
            Renderer[] renderers = potionObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
            {
                Color color = r.material.color;
                color.a = 0.5f;
                r.material.color = color;
            }
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


}
