using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestStatus : Chest, IChest
{
    public bool lockedStatus;

    private void Awake()
    {
        title = gameObject.name;
        isLocked = lockedStatus;
    }

    public void ChangeLockedStatus()
    {
        isLocked = false;
    }

    public bool IsLocked()
    {
        return isLocked;
    }

   
}
