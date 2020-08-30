using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMessage : MonoBehaviour
{
    public string exitName = "Locked";

  public void Locked()
    {
        RaycastManager.instance.itemNameText.text = "Locked";
        FMODUnity.RuntimeManager.PlayOneShot("event:/Interactable/Exit");

    }
}
