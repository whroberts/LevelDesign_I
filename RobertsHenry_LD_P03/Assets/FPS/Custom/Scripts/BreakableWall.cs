using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Game;

public class BreakableWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        DamageArea da = other.GetComponent<DamageArea>();

        if (da != null)
        {
            Debug.Log("Wall Trigger");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageArea da = collision.gameObject.GetComponent<DamageArea>();

        if (da != null)
        {
            Debug.Log("Wall Collision");
        }
    }
}
