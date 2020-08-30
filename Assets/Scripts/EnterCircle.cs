using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCircle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.instance.sulfurState == true)
        {
            GameManager.instance.circleStatus = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.instance.sulfurState == true)
        {
            GameManager.instance.circleStatus = false;

        }
    }

}
