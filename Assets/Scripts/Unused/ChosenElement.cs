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

}
   