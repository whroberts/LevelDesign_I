using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Game;

public class Button : MonoBehaviour
{
    [Header("Wall To Move")]
    [SerializeField] GameObject _wallToMove = null;

    [Header("Audio")]
    [SerializeField] AudioClip _wallOpen = null;

    [Header("Enemies")]
    [SerializeField] GameObject _smallEnemy = null;

    [Header("Booleans")]
    public bool _useWall = false;
    public bool _useCamera = false;
    public bool _enemies = false;

    Animator _wallAnim;
    AudioSource _audioSource;

    bool _unlocked = false;

    private void Start()
    {
        _wallAnim = _wallToMove.GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Health healthScript = other.GetComponent<Health>();

        if (healthScript != null)
        {
            WallControl();
            SpawnEnemies();
        }
    }

    void WallControl()
    {
        if (_useWall)
        {
            if (!_unlocked)
            {
                Unlock();
            }
            else if (_unlocked)
            {
                Lock();
            }
        }
    }

    void SpawnEnemies()
    {
        if(_enemies)
        {
            GameObject enemy = Instantiate(_smallEnemy);
            enemy.transform.position = new Vector3(48, 8.5f, -63);
        }
    }

    void Unlock()
    {
        _wallAnim.SetTrigger("Unlock");
        _audioSource.PlayOneShot(_wallOpen);
        _unlocked = true;
    }

    void Lock()
    {
        _wallAnim.SetTrigger("Lock");
        _unlocked = false;
    }
}
