using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class Interaction : MonoBehaviour
    {
        public Transform _interactionPivot;

        void Update()
        {
            _interactionPivot.LookAt(Camera.main.transform.position);
        }
    }
}