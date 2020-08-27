using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : MonoBehaviour
{
    public static EndState instance;
    public GameObject thirdPrime, spotLight;

    private void Awake()
    {
        instance = this;
    }
    public void ShowThird()
    {
        thirdPrime.SetActive(true);
        spotLight.SetActive(true);

    }
}
