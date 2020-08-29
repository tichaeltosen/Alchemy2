using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDark : MonoBehaviour
{
    public static PartDark instance;
    public GameObject particle;
    public Transform player;
    public float distance = 2.0f;

    private void Awake()
    {
        instance = this;
    }

    public void DarkEndParticle()
    {
        GameObject darkEnd = Instantiate(particle, player.position + player.transform.forward * distance, particle.transform.rotation);

    }
}
