using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class LolipopScript : MonoBehaviour
    {
        public bool _collected = false;
        private void OnTriggerEnter2D(Collider2D col)
        {
            PlayerController playerController = col.GetComponent<PlayerController>();

            if (playerController != null)
            {
                Collect();
            }
        }

        void Collect()
        {
            _collected = true;
            this.gameObject.SetActive(false);
        }

        public void Give()
        {
            this.gameObject.SetActive(true);
            transform.position = new Vector2(36.5f, 5.61f);
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.enabled = false;
        }
    }
}
