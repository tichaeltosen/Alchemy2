using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MakePotion : MonoBehaviour
{
    public static MakePotion instance;

    public bool canCreatePotion;

    [SerializeField]
    private Text itemNameText;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        canCreatePotion = GameManager.instance.count == 2 ? true : false;
        if (canCreatePotion)
        {
           //
        }

    }

 
}
