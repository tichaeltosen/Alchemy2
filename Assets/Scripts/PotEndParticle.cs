using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotEndParticle : MonoBehaviour
{
    public static PotEndParticle instance;
    public GameObject particle;
    public Transform player;
    public float distance = 2.0f;

    private void Awake()
    {
        instance = this;
    }

    public void PotionParticle()
    {
        Debug.Log("Potion Particle");
        GameObject potEnd = Instantiate(particle, player.position + player.transform.forward * distance, particle.transform.rotation, player);
        Destroy(potEnd, 1.0f);

    }
}
