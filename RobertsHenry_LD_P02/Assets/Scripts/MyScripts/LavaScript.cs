using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics {
    public class LavaScript : MonoBehaviour
    {
        [SerializeField] ParticleSystem _lavaParticle = null;
        [SerializeField] DisableColliderScript _disableCollider = null;

        private void OnTriggerEnter2D(Collider2D col)
        {
            PlayerController playerControlller = col.GetComponent<PlayerController>();

            if (playerControlller != null && !_disableCollider._hit)
            {
                 _lavaParticle.Play();
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            PlayerController playerControlller = col.GetComponent<PlayerController>();

            if (playerControlller != null)
            {
                _lavaParticle.Stop();
            }
        }
    }
}
