using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class BreakableFloor : MonoBehaviour
    {
        [SerializeField] GameObject _floor = null;

        PlayerController _playerController;

        private void Awake()
        {
            _playerController = FindObjectOfType<PlayerController>();
        }

        private void Update()
        {
            
        }
    }
}
