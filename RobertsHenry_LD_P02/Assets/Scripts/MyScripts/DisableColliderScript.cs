using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics {
    public class DisableColliderScript : MonoBehaviour
    {

        public bool _hit = false;

        private void OnTriggerEnter2D(Collider2D col)
        {
            PlayerController playerController = col.GetComponent<PlayerController>();

            if (playerController != null)
            {
                _hit = true;
            }
        }
    }
}
