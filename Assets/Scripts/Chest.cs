using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Chest : MonoBehaviour
{
    public string title
    {
        get; set;
    }


    public bool isLocked
    {
        get; set;
    }

}