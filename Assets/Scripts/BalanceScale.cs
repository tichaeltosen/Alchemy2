using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceScale : MonoBehaviour
{
    public GameObject unbalanced, balanced;

    public static BalanceScale instance;

    private void Awake()
    {
        instance = this;
    }

    public void Balance()
    {
        Debug.Log("Hidden Door Revealed");
        unbalanced.SetActive(false);
        balanced.SetActive(true);
        UsePotion.Effect -= Balance;

    }
}
