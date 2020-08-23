using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementStatus : Element, IElement
{
    public bool rackStatus;
    public Transform rackPos;
    

    private void Awake()
    {
        title = gameObject.name;
        isRacked = rackStatus;
    }

    public bool IsRacked()
    {
        return isRacked;
    }

    public void ChangeRackedStatus()
    {
        isRacked = true;
    }

    public void MoveElement()
    {
        transform.position = rackPos.position;
    }
}
