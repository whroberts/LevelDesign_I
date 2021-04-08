using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    [SerializeField] GameObject _solidRock;
    [SerializeField] float _spawnRate = 5f;

    FallingRocks _fallingRocks;
    float _nextSpawnTime = 0f;

    private void Awake()
    {
        _fallingRocks = _solidRock.GetComponent<FallingRocks>();
    }

    private void Start()
    {
        StartCoroutine("SpawnDebris");
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //StartCoroutine("SpawnDebris");
        }


    }

    IEnumerator SpawnDebris()
    {
        while (true)
        {
            Vector3 spawnLocation = new Vector3(transform.position.x + Random.Range(-5f, 5f), transform.position.y, transform.position.z + Random.Range(-5f, 5f));
            Instantiate(_solidRock, spawnLocation, transform.rotation);
            print("Spawned");
            yield return new WaitForSeconds(1.5f);
        }
    }
}
