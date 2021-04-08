using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Platformer.Mechanics;

public class StartUp : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _camera = null;
    [SerializeField] CinemachineTargetGroup _targetGroup = null;
    [SerializeField] GameObject _player;

    [SerializeField] Transform _level_1 = null;
    [SerializeField] Transform _level_2 = null;
    [SerializeField] Transform _level_3 = null;
    [SerializeField] Transform _level_4 = null;

    PlayerController _playerController;

    float _waitFor = 2f;
    int _numTargets;

    private void Awake()
    {
        _playerController = _player.GetComponent<PlayerController>();
        _playerController.controlEnabled = false;
        StartCoroutine(StartAll());
    }

    IEnumerator Begin()
    {
        _targetGroup.AddMember(_player.transform, 1, 4f);
        yield return new WaitForSeconds(_waitFor);
        _targetGroup.RemoveMember(_player.transform);
        StartCoroutine(Level1());
    }
    IEnumerator Level1()
    {
        _targetGroup.AddMember(_level_1, 1.0f, 8f);
        yield return new WaitForSeconds(_waitFor);
        _targetGroup.RemoveMember(_level_1);
        StartCoroutine(Level2());
    }

    IEnumerator Level2()
    {
        _targetGroup.AddMember(_level_2, 1.0f, 8f);
        yield return new WaitForSeconds(_waitFor);
        _targetGroup.RemoveMember(_level_2);
        StartCoroutine(Level3());
    }
    IEnumerator Level3()
    {
        _targetGroup.AddMember(_level_3, 1.0f, 8f);
        yield return new WaitForSeconds(_waitFor);
        _targetGroup.RemoveMember(_level_3);
        StartCoroutine(Level4());
    }
    IEnumerator Level4()
    {
        _targetGroup.AddMember(_level_4, 1.0f, 8f);
        yield return new WaitForSeconds(_waitFor);
        _targetGroup.RemoveMember(_level_4);
        StartCoroutine(AllLevels());
    }

    IEnumerator AllLevels()
    {
        _targetGroup.AddMember(_level_1, 1.0f, 8f);
        _targetGroup.AddMember(_level_2, 1.0f, 8f);
        _targetGroup.AddMember(_level_3, 1.0f, 8f);
        _targetGroup.AddMember(_level_4, 1.0f, 8f);
        
        yield return new WaitForSeconds(_waitFor);
    }

    void ReturnToNormal()
    {
        _targetGroup.RemoveMember(_level_1);
        _targetGroup.RemoveMember(_level_2);
        _targetGroup.RemoveMember(_level_3);
        _targetGroup.RemoveMember(_level_4);
        _targetGroup.AddMember(_player.transform, 1.0f, 4f);
    }

    IEnumerator StartAll()
    {
        StartCoroutine(Begin());
        yield return new WaitForSeconds(12f);
        ReturnToNormal();
        _playerController.controlEnabled = true;
    }
}
