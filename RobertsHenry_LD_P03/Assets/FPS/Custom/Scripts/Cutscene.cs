using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Gameplay;

public class Cutscene : MonoBehaviour
{
    [SerializeField] Camera _weaponCamera = null;
    [SerializeField] Camera _playerCamera = null;
    [SerializeField] PlayerInputHandler _pIH = null;
    [SerializeField] GameObject _ui = null;

    Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        StartCoroutine(StartCutscene());
    }

    IEnumerator StartCutscene()
    {
        _pIH.enabled = false;
        _playerCamera.enabled = false;
        _weaponCamera.enabled = false;
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(IStartCutscene());
    }

    IEnumerator IStartCutscene()
    {
        _ui.SetActive(false);
        _anim.SetTrigger("start");
        yield return new WaitForSeconds(38f);
        _weaponCamera.enabled = true;
        _playerCamera.enabled = true;
        _pIH.enabled = true;
        _ui.SetActive(true);
        Destroy(this.gameObject);
    }
}
