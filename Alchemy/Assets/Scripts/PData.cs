using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PData : MonoBehaviour
{
    public List<PName> potion = new List<PName>();
    public string[] pArray = { "Moon", "Sun", "Strength" };
    public static PData instance;

    void Awake()
    {
        BuildData();
       // Debug.Log(potion.Count);
        
    }

    private void Start()
    {
        instance = this;
    }

    void BuildData()
    {
        potion = new List<PName>();
            for(int i = 0; i < pArray.Length; i++)
        {
            PName p = new PName(pArray[i]);
            potion.Add(p);
        }

    }

    PName FindPotion(PName name)
    {
       foreach(PName n in potion)
        {
            if(n == name)
            {
                //maybe trigger the potion here
                return n;
            }
        }
        return null;
    }
    
}
