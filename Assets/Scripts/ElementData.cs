using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementData : MonoBehaviour
{
    public List<string> elementList;
    public static ElementData instance;
    bool rStatus;

    GameObject[] elements;


    private void Awake()
    {
        instance = this;

        elementList = new List<string>();

        elements = GameObject.FindGameObjectsWithTag("Element");

        // if element is active in scene, add to list. maybe for inventory?

        foreach (GameObject e in elements)
        {
            if (e.activeSelf)
            {
                elementList.Add(e.name);
            }
        }


    }

    public bool FindElement(string name)
    {
        
        foreach (string e in elementList)
        {
            if (e == name)
            {
                //maybe trigger the potion here
                return true;
            }
        }
        return false;
    }
}
