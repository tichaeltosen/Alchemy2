using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillNote : MonoBehaviour
{
   public void NoteKill()
    {
        gameObject.SetActive(false);
        Debug.Log("Kill Note");
    }
}
