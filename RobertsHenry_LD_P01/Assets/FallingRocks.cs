using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRocks : MonoBehaviour
{
    [SerializeField] GameObject _smallRock;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(_smallRock, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
