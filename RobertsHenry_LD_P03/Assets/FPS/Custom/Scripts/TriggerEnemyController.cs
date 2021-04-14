using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyController : MonoBehaviour
{
    [SerializeField] InteractionDistance _interactionDistance = null;

    TriggerEnemies _triggerEnemies;

    private void Start()
    {
        _triggerEnemies = GetComponent<TriggerEnemies>();
    }

    private void Update()
    {
        if (_interactionDistance._interactable)
        {
            HandleInputs();
        }
    }

    void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _triggerEnemies.SpawnEnemies();
        }
    }
}
