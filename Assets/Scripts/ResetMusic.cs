using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMusic : MonoBehaviour
{
    FMOD.Studio.EventInstance mReset;

    [FMODUnity.EventRef]
    public string fmodEvent;

    private void Awake()
    {
        mReset = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        

    }

    private void Start()
    {
        mReset.setParameterByName("Light", 0f);
        mReset.setParameterByName("Dark", 0f);
        mReset.setParameterByName("Ritual", 0f);
    }

}
