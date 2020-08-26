using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChest 
{
    bool IsLocked();
    void ChangeLockedStatus();
}
