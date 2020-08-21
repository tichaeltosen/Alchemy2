using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastManager : MonoBehaviour
{
    public static RaycastManager instance;
    public Text itemNameText;
    public bool creatingPotion;

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

                }
            }
            else if (hit.collider.CompareTag("MakePotion"))
            {
                CrosshairActive();
                raycastedObj = hit.collider.gameObject;

                if (GameManager.instance.count < 2 && !creatingPotion)
                {
                   itemNameText.text = "Choose Elements To Create Potion";

                }else if (GameManager.instance.count == 2 && !creatingPotion)
                {
                   itemNameText.text = "Click To Create Potion";

                }
                if (Input.GetMouseButtonDown(0))
                {
                    raycastedObj.GetComponent<PotionEventManager>().CreatingPotion();
                }
                
            }
        }else
        {
            CrosshairNormal();
            if (!creatingPotion)
            {
                itemNameText.text = "";
            }
        }
    }

    void CrosshairActive()
    {
        crossHair.color = Color.red;
    }

    void CrosshairNormal()
    {
        crossHair.color = Color.white;
    }

}
