using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartElectric : MonoBehaviour
{
    public static PartElectric instance;
    public GameObject particle;
    public Transform player;
    public float distance = 4.0f;
    public float lightningTime = 4.0f;

    private void Awake()
    {
        instance = this;
    }

    public void ElectricParticle()
    {
        GameObject electric = Instantiate(particle, player.position + player.transform.forward * distance, particle.transform.rotation, player);
        Destroy(electric, lightningTime);

    }
}
