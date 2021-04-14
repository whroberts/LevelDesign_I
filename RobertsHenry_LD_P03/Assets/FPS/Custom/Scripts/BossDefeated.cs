using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDefeated : MonoBehaviour
{
    [Header("Reach Point To Enable")]
    [SerializeField] GameObject _reachPoint = null;

    MeshCollider _reachMesh;
    MeshRenderer _pointRender;

    private void Start()
    {
        _reachMesh = _reachPoint.GetComponent<MeshCollider>();
        _pointRender = _reachPoint.GetComponent<MeshRenderer>();

    }
    private void OnDestroy()
    {
        _reachMesh.enabled = true;
        _pointRender.enabled = true;
    }
}
