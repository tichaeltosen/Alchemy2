using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public GameObject currentExit, lightExit, darkExit;

    public static ExitDoor instance;

    private void Awake()
    {
        instance = this;
    }

    public void LightExit()
    {
        currentExit.SetActive(false);
        lightExit.SetActive(true);
        darkExit.SetActive(false);

    }

    public void DarkExit()
    {
        currentExit.SetActive(false);
        darkExit.SetActive(true);
        lightExit.SetActive(false);

    }
}
