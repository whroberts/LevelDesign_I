using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Platformer.Mechanics;

public class LookAtScript : MonoBehaviour
{
    CinemachineVirtualCamera _camera;
    PlayerController _playerController;
    CinemachineTargetGroup _targetGroup;

    Transform _player;

    private void Awake()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
        _targetGroup = FindObjectOfType<CinemachineTargetGroup>();
        _playerController = FindObjectOfType<PlayerController>();
        _player = _playerController.transform;
    }

    private void Update()
    {
        _camera.Follow = _targetGroup.transform;
        _camera.LookAt = _targetGroup.transform;
    }

    public IEnumerator MoveTo(Transform _objectToFollow)
    {
        _targetGroup.AddMember(_objectToFollow, 1.0f, 4f);
        yield return new WaitForSeconds(2f);
        _targetGroup.RemoveMember(_objectToFollow);
    }

    public IEnumerator MoveTo2(Transform _objectToFollow)
    {
        _camera.Follow = _objectToFollow;

        yield return new WaitForSeconds(2f);

        _camera.Follow = _player;
    }


}
