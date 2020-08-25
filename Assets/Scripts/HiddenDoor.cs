using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenDoor : MonoBehaviour
{
    public GameObject wall, door;

    public static HiddenDoor instance;

    private void Awake()
    {
        instance = this;
    }

    public void ShowDoor()
    {
        Debug.Log("Hidden Door Revealed");
        wall.SetActive(false);
        door.SetActive(true);
        UsePotion.Effect -= ShowDoor;

    }
}
