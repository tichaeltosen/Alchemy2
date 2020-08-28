using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public static Smoke instance;
    public GameObject particle;
    public Transform player;
    public float distance = 3.0f;
    public float smokeTime = 3.0f;

    private void Awake()
    {
        instance = this;
    }

    public void SmokeParticle()
    {
        GameObject smoke = Instantiate(particle, player.position + player.transform.forward * distance, particle.transform.rotation, player);
        Destroy(smoke, smokeTime);

    }
}
