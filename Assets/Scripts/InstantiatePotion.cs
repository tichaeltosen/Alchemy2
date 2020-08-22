using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePotion : MonoBehaviour
{
    private string potion;
    public GameObject getPotion;
    public GameObject sun, moon, feather, strength, fertility, shrinking, electric, heavy, sound;
    public Transform player;
    public float distance = 1f;
    private void Start()
    {
        PotionEventManager.PotionInstantiate += PotionToGame;
    }



    public void PotionToGame()
    {
        potion = getPotion.GetComponent<PotionEventManager>().potionReturn;
        Debug.Log("Testing Potion Instantiating Script:  " + potion);

        switch(potion)
        {
            case "Moon":
                CreateInstance(moon);

                break;

            case "Sun":
                CreateInstance(moon);

                break;

            case "Feather":
                CreateInstance(moon);

                break;

            case "Strength":
                CreateInstance(moon);

                break;

            case "Fertility":
                CreateInstance(moon);

                break;

            case "Shrinking":
                CreateInstance(moon);

                break;

            case "Electric":
                CreateInstance(moon);

                break;

            case "Heavy":
                CreateInstance(moon);


                break;

            case "Sound":
                CreateInstance(moon);

                break;

            case "None":
                //do something for default no potion 


                break;


        }


    }

    private void CreateInstance(GameObject name)
    {
        Vector3 shiftLeft = new Vector3(-.15f, -.15f, 0f);
        name = Instantiate(name, player.transform.position + shiftLeft + transform.forward * distance, player.transform.rotation);
        name.transform.SetParent(player);
    }


}
