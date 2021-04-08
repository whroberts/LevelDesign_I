using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

namespace Platformer.Mechanics
{
    public class PortalScript : MonoBehaviour
    {
        [SerializeField] Animator _playerAnim = null;
        [SerializeField] GameObject _outPortal = null;
        [SerializeField] bool _forPlayer = true;
        [SerializeField] bool _forBox = true;

        Transform _outPortalTrans;

        private void Awake()
        {
            _outPortalTrans = _outPortal.transform;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            MoveableObjectScript moveableObjectScript = other.GetComponent<MoveableObjectScript>();
            print("ENTERED");
            if (playerController != null && _forPlayer)
            {
                _playerAnim.SetTrigger("portal");
                other.transform.position = _outPortalTrans.position;

            } else if (moveableObjectScript != null && _forBox)
            {
                moveableObjectScript.ThroughPortal(other, _outPortalTrans);
            }
        }
    }
}
