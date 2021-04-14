using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemies : MonoBehaviour
{
    [SerializeField] GameObject _smallEnemy = null;
    [SerializeField] GameObject _largeEnemy = null;
    [SerializeField] float _chanceForBoss = 10;


    public void SpawnEnemies()
    {
        int numEnemies = Random.Range(1, 5);

        if (Random.Range(0,100) < _chanceForBoss)
        {
            GameObject enemy = Instantiate(_largeEnemy);
            enemy.transform.localPosition = new Vector3(Random.Range(0, 15), 0, Random.Range(0, 15));
        }

        for (int i = 0; i < numEnemies; i++)
        {
            GameObject enemy = Instantiate(_smallEnemy);
            enemy.transform.localPosition = new Vector3(Random.Range(0, 15), 0, Random.Range(-15, 15));

        }
    }

}
