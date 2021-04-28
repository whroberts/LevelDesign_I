using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS;

public class DestructableWall : MonoBehaviour
{
    [Header("Stats")]
    public float _wallHealth = 1f;
    float _currentWallHealth = 0f;

    private void Awake()
    {
        _currentWallHealth = _wallHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("WALL1");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Wall2");
    }

    public void Break()
    {
        this.gameObject.SetActive(false);
    }
}
