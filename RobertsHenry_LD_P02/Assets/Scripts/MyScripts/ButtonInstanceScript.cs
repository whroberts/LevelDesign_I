using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class ButtonInstanceScript : MonoBehaviour
    {
        [SerializeField] GameObject _wallToMove = null;
        [SerializeField] GameObject _portalToShow = null;
        [SerializeField] Transform _objectToFollow = null;

        LookAtScript _lookAtScript;
        Animator _wallAnim;

        PlayerController _playerController;

        bool _firstTouch = true;

        private void Awake()
        {
            _lookAtScript = FindObjectOfType<LookAtScript>();
            _wallAnim = _wallToMove.GetComponent<Animator>();
            _playerController = FindObjectOfType<PlayerController>();
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            PlayerController pc = col.GetComponent<PlayerController>();
            MoveableObjectScript mos = col.GetComponent<MoveableObjectScript>();

            print(col);

            if (pc != null)
            {
                if (_firstTouch)
                {

                    if (tag == "Up")
                    {
                        LockWall();
                    }
                    else if (tag == "Down")
                    {
                        UnlockWall();
                    }
                    else if (tag == "Portal")
                    {
                         ShowPortal();
                    }
                }
            } 
            else if (mos != null)
            {

                if (_firstTouch)
                {

                    if (tag == "HeavyUp")
                    {
                        LockWall();
                    }
                    else if (tag == "HeavyDown")
                    {
                        UnlockWall();
                    }
                    else if (tag == "HeavyPortal")
                    {
                        ShowPortal();
                    }
                    else if (tag == "HeavyWait")
                    {
                        StartCoroutine(Waiting());
                    }
                    mos.Leave(this.transform);
                }
            }
        }

        public void UnlockWall()
        {
            _wallAnim.SetTrigger("Unlock");
            _playerController._boxCollected = false;
            StartCoroutine(_lookAtScript.MoveTo(_objectToFollow));
            StartCoroutine(FirstTouch());
        }

        public void LockWall()
        {
            _wallAnim.SetTrigger("Lock");
            _playerController._boxCollected = false;
            StartCoroutine(_lookAtScript.MoveTo(_objectToFollow));
            StartCoroutine(FirstTouch());
        }

        public void ShowPortal()
        {
            _portalToShow.SetActive(true);
            _playerController._boxCollected = false;
            StartCoroutine(_lookAtScript.MoveTo(_objectToFollow));
            StartCoroutine(FirstTouch());
        }

        public void DisableCollider()
        {
            BoxCollider2D clone = this.gameObject.GetComponent<BoxCollider2D>();
            clone.enabled = false;
        }
        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(0.5f);
            UnlockWall();
        }

        IEnumerator FirstTouch()
        {
            _firstTouch = false;
            yield return new WaitForSeconds(4f);
            _firstTouch = true;
        }
    }
}
