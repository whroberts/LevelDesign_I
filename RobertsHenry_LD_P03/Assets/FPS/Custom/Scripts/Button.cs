using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Game;

public class Button : MonoBehaviour
{
    [Header("Wall To Move")]
    [SerializeField] GameObject _wallToMove = null;

    [Header("Booleans")]
    public bool _useWall = false;
    public bool _useCamera = false;

    Animator _wallAnim;

    bool _unlocked = false;

    private void Start()
    {
        _wallAnim = _wallToMove.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Health healthScript = other.GetComponent<Health>();

        if (healthScript != null)
        {
            WallControl();
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

    void Unlock()
    {
        _wallAnim.SetTrigger("Unlock");
        _unlocked = true;
    }

    void Lock()
    {
        _wallAnim.SetTrigger("Lock");
        _unlocked = false;
    }
}
