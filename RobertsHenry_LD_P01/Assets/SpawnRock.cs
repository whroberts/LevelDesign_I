using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRock : MonoBehaviour
{
    [SerializeField] GameObject _solidRock;
    [SerializeField] Transform _spawnLocation;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Instantiate(_solidRock, _spawnLocation.position, _spawnLocation.rotation);
            Destroy(this.gameObject);
        }
        
    }
}
