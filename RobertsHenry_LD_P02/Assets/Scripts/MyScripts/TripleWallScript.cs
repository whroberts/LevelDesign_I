using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class TripleWallScript : MonoBehaviour
{
    public bool _left = false;
    public bool _right = false;
    [SerializeField] GameObject _wallToMove = null;

    Animator _wallAnim;
    BoxCollider2D _bc;

    private void Awake()
    {
        _wallAnim = _wallToMove.GetComponent<Animator>();
        _bc = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        MoveableObjectScript mos = other.GetComponent<MoveableObjectScript>();
        if (mos != null)
        {
            if (_left)
            {
                _wallAnim.SetTrigger("UnlockLeft");
            }
            else if (_right)
            {
                _wallAnim.SetTrigger("UnlockRight");
            }
        }
    }
}
