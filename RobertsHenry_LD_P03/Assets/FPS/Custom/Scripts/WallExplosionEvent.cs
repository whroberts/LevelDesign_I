using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Gameplay;

public class WallExplosionEvent : MonoBehaviour
{
    [SerializeField] GameObject _wall = null;
    [SerializeField] ParticleSystem _wallExplosion = null;
    [SerializeField] Transform _explosionLocation = null;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInputHandler pih = other.GetComponent<PlayerInputHandler>();

        if (pih != null)
        {
            StartCoroutine(BlowUpWall());
        }
    }

    IEnumerator BlowUpWall()
    {
        yield return new WaitForSeconds(0.5f);
        _wallExplosion.transform.position = _explosionLocation.position;
        _wallExplosion.Play();
        _wall.SetActive(false);
        BoxCollider col = this.GetComponent<BoxCollider>();
        col.enabled = false;
    }
}
