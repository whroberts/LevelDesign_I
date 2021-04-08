using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class AlienScript : MonoBehaviour
    {
        [SerializeField] LolipopScript _lolipopScript = null;

        [SerializeField] GameObject _drawBridgeUp = null;
        [SerializeField] GameObject _drawBridgeDown = null;

        private void OnTriggerEnter2D(Collider2D col)
        {
            PlayerController playerController = col.GetComponent<PlayerController>();

            if (playerController != null && _lolipopScript._collected)
            {
                _lolipopScript.Give();
                _drawBridgeUp.SetActive(false);
                _drawBridgeDown.SetActive(true);
                BoxCollider2D collider = GetComponent<BoxCollider2D>();
                collider.enabled = false;
            }
        }
    }
}
