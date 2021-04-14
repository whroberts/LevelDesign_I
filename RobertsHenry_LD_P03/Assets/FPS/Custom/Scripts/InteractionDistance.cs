using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Gameplay;

public class InteractionDistance : MonoBehaviour
{
    public bool _interactable = false;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInputHandler inputHandler = other.GetComponent<PlayerInputHandler>();

        if (inputHandler != null)
        {
            _interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerInputHandler inputHandler = other.GetComponent<PlayerInputHandler>();

        if (inputHandler != null)
        {
            _interactable = false;
        }
    }
}
