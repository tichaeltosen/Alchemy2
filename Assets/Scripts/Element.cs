using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element 
{
    public string title
    {
        get; set;
    }


    public bool isActive
    {
        get; set;
    }

    public Element(string title)
    {
        this.title = title;
    }

    
}
 