using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public GameObject closed, open;

    public void Open()
    {
        closed.SetActive(false);
        open.SetActive(true);
    }

}
