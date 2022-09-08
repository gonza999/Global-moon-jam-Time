using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject particle;
    public Transform positionToParticle;

    public void Destroy()
    {
        Instantiate(particle,positionToParticle.transform.position,positionToParticle.transform.rotation);
        Destroy(gameObject);
    } 
}
