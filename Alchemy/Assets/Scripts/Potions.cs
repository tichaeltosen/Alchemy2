using UnityEngine;
using System.Collections;

public class PName : IPersistable
{

    public string title;
    public bool isActive
    {
        get; set;
    }
    public PName()
    {

    }
    public PName(string aName)
    {
        this.title = aName;
    }

    public void Save()
    {
        // Debug.Log("save");
    }

}
