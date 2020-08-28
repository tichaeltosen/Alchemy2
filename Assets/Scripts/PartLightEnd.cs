using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartLightEnd : MonoBehaviour
{
    public static PartLightEnd instance;
    public GameObject particle;
    public Transform player;
    public float distance = 2.0f;

    private void Awake()
    {
        instance = this;
    }

    public void LightEndParticle()
    {
        Debug.Log("Potion Particle");
        GameObject lightEnd = Instantiate(particle, player.position + player.transform.forward * distance, particle.transform.rotation);

    }
}
