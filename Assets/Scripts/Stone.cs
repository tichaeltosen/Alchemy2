using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{

    FMOD.Studio.EventInstance pStone;

    private void Awake()
    {
        pStone = FMODUnity.RuntimeManager.CreateInstance("event:/Ending/Stone");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(pStone, GetComponent<Transform>(), GetComponent<Rigidbody>());

    }

    private void OnEnable()
    {
        pStone.start();
        Debug.Log("enabled");

    }
}
