using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenElement : MonoBehaviour
{
    public List<string> chosenEl = new List<string>();

    public static ChosenElement instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PotionEventManager.PotionCreate += CompareElements;
    }


    void CompareElements()
    {
        string firstEl = chosenEl[0];
        string secondEl = chosenEl[1];

        //gold and silver
        if((firstEl == "Gold" || secondEl == "Gold") && (firstEl == "Silver" || secondEl == "Silver"))
        {
            Debug.Log("You've Created Moon");
        }

    }



}
