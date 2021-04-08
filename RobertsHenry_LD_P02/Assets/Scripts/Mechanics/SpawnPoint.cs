using UnityEngine;
using Platformer.Model;
using Platformer.Core;
using Platformer.Mechanics;

/// <summary>
/// Marks a gameobject as a spawnpoint in a scene.
/// </summary>
public class SpawnPoint : MonoBehaviour
{
    public Transform _currentCheckpoint;
    [SerializeField] Platformer.Mechanics.GameController _gameController;
    private void Awake()
    {
        _currentCheckpoint = this.gameObject.transform;
    }

    private void Update()
    {
        _gameController.model.spawnPoint  = _currentCheckpoint;
    }
}