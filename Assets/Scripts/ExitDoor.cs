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
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ending/Light Door", GetComponent<Transform>().position);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ending/Light End");
        currentExit.SetActive(false);
        lightExit.SetActive(true);
        darkExit.SetActive(false);

    }

    public void DarkExit()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ending/Dark Door", GetComponent<Transform>().position);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ending/Dark End");
        currentExit.SetActive(false);
        darkExit.SetActive(true);
        lightExit.SetActive(false);

    }
}
