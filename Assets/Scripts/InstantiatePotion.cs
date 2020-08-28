﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePotion : MonoBehaviour
{
    public GameObject getPotion;
    public GameObject sun, moon, feather, strength, fertility, shrinking, electric, heavy, sound, wine, particleEffect;
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
                break;

            case "Strength":
                UsePotion.Effect += StrengthPotion.instance.StrengthChest;
                UsePotion.Effect += StrengthEnd.instance.DarkEnd;

                InstPotion(strength);
                break;

            case "Fertility":
                InstPotion(fertility);
                UsePotion.Effect += PotionEffects.instance.Fertility;
                UsePotion.Effect += FertEnd.instance.LightEnd;
                break;

            case "Shrinking":
                InstPotion(shrinking);
                UsePotion.Effect += PlayerShrink.instance.Shrinking;

                break;

            case "Electric":
                InstPotion(electric);
                UsePotion.Effect += ElectricPotion.instance.ElectricChest;
                break;

            case "Heavy":
                InstPotion(heavy);
                UsePotion.Effect += PlayerSlow.instance.Slow;
                break;

            case "Sound":
                InstPotion(sound);
                UsePotion.Effect += SoundPotion.instance.SoundPo;
                break;

            case "Iron Wine":
                InstPotion(wine);
                UsePotion.Effect += PlayerReverse.instance.ReversePlayer;
                break;

            case "None":
                Smoke.instance.SmokeParticle();
                break;
        }

    }

    public void InstPotion(GameObject name)
    {
        GameObject newObj = Instantiate(name, player.position + player.transform.forward * distance, player.rotation, player);
        newObj.gameObject.AddComponent<UsePotion>();
        GameObject particle = Instantiate(particleEffect, player.position + player.transform.forward * distance, particleEffect.transform.rotation, player);
        Destroy(particle, 1.0f);
    }


}
