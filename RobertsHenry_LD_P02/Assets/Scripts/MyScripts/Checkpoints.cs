using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Model;
using Platformer.Mechanics;

public class Checkpoints : MonoBehaviour
{
    SpawnPoint _spawnPoint;

    private void Awake()
    {
        _spawnPoint = FindObjectOfType<SpawnPoint>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var c = other.gameObject.GetComponent<PlayerController>();

        if (c != null)
        {
            _spawnPoint._currentCheckpoint = this.gameObject.transform;
            Debug.Log(_spawnPoint._currentCheckpoint);
        }
    }
}
