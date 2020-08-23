using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IElement
{
    bool IsRacked();
    void ChangeRackedStatus();
    void MoveElement();
}
