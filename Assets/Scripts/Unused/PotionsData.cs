using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsData : Potions
{
    public GameObject[] potions;

    private void Start()
    {
        foreach(GameObject p in potions)
        {
            title = p.name;
            isActive = false;
        }
       
    }

}
