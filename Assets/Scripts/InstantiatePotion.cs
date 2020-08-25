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
                InstPotion(moon);
                UsePotion.Effect += PotionEffects.instance.Moon;
                break;

            case "Sun":
                InstPotion(sun);
                UsePotion.Effect += PotionEffects.instance.Sun;
                break;

            case "Feather":
                InstPotion(feather);
                UsePotion.Effect += PlayerFloat.instance.Feather;
                //add one for the feather on the scale too
                break;

            case "Strength":
                InstPotion(strength);
                UsePotion.Effect += PotionEffects.instance.Strength;
                break;

            case "Fertility":
                InstPotion(fertility);
                UsePotion.Effect += PotionEffects.instance.Fertility;
                break;

            case "Shrinking":
                InstPotion(shrinking);
                UsePotion.Effect += PlayerShrink.instance.Shrinking;

                break;

            case "Electric":
                InstPotion(electric);
                UsePotion.Effect += PotionEffects.instance.Electric;
                break;

            case "Heavy":
                InstPotion(heavy);
                UsePotion.Effect += PotionEffects.instance.Heavy;
                break;

            case "Sound":
                InstPotion(sound);
                UsePotion.Effect += PotionEffects.instance.Sound;
                break;

            case "None":
                //do something for default no potion
                break;
        }

    }

    public void InstPotion(GameObject name)
    {
        GameObject newObj = Instantiate(name, player.position + player.transform.forward * distance, player.rotation, player);
        newObj.gameObject.AddComponent<UsePotion>();
    }


}
