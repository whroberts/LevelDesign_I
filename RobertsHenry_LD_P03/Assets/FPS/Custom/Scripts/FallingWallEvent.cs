using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Gameplay;

public class FallingWallEvent : MonoBehaviour
{
    [SerializeField] GameObject _wall = null;

    Animator _anim;
    AudioSource _audioSource;

    private void Start()
    {
        _anim = _wall.GetComponent<Animator>();
        _audioSource = _wall.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInputHandler pih = other.GetComponent<PlayerInputHandler>();
        Debug.Log("Entered");

        if (pih != null)
        {
            StartCoroutine(DropWall());
        }
    }
    IEnumerator DropWall()
    {
        _anim.SetTrigger("drop");
        yield return new WaitForSeconds(1f);
        _audioSource.Play();
        BoxCollider col = this.GetComponent<BoxCollider>();
        col.enabled = false;
    }
}
