using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePotion : MonoBehaviour
{
    private string potion;
    public GameObject sun, moon, gravity;
    public Transform player;
    public float distance = 0.5f;
    private void Start()
    {
        PotionEventManager.PotionInstantiate += PotionToGame;
    }



    public void PotionToGame()
    {
        potion = gameObject.GetComponent<CraftRecipe>().potion;
        Debug.Log("Testing Potion Instantiating Script:  " + potion);

        switch(potion)
        {
            case "Moon":

                GameObject childMoon = Instantiate(moon, player.transform.position + transform.forward * distance, player.transform.rotation);
                childMoon.transform.SetParent(player);



                break;

            case "Sun":
                GameObject childSun = Instantiate(moon, player.transform.position + transform.forward * distance, player.transform.rotation);
                childSun.transform.SetParent(player);


                break;

            case "Gravity":
                GameObject childGravity = Instantiate(moon, player.transform.position + transform.forward * distance, player.transform.rotation);
                childGravity.transform.SetParent(player);


                break;


        }


    }


}
