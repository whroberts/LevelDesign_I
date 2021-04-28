using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        DestructableWall dw = other.GetComponent<DestructableWall>();
        Debug.Log("HIT1");
        dw?.Break();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT2");
    }
}
