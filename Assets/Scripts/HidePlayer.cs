using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayer : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.SetActive(false);
    }
}
