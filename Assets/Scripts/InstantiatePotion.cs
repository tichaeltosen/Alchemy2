using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePotion : MonoBehaviour
{
    public GameObject getPotion;
    public GameObject sun, moon, feather, strength, fertility, shrinking, electric, heavy, sound;
    public Transform player;
    public float distance = 2f;

    private string potion;



    private Transform Appear;

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
                Instantiate(moon, player.position + player.transform.forward * distance, player.rotation, player);
                break;

            case "Sun":
                Instantiate(moon, player.position + player.transform.forward * distance, player.rotation, player);

                break;

            case "Feather":
                Instantiate(moon, player.position + player.transform.forward * distance, player.rotation, player);

                break;

            case "Strength":
                Instantiate(moon, player.position + player.transform.forward * distance, player.rotation, player);

                break;

            case "Fertility":
                Instantiate(moon, player.position + player.transform.forward * distance, player.rotation, player);

                break;

            case "Shrinking":
                Instantiate(moon, player.position + player.transform.forward * distance, player.rotation, player);

                break;

            case "Electric":
                Instantiate(moon, player.position + player.transform.forward * distance, player.rotation, player);

                break;

            case "Heavy":
                Instantiate(moon, player.position + player.transform.forward * distance, player.rotation, player);


                break;

            case "Sound":
                Instantiate(moon, player.position + player.transform.forward * distance, player.rotation, player);

                break;

            case "None":
                //do something for default no potion 


                break;


        }


    }


}
