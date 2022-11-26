using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerJump : MonoBehaviour
{
    private PlayerInput _playerInput;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.OnPlayerJumped += Jump;
    }

    private void Jump()
    {
        transform.DOJump(new Vector3(0, transform.position.y + 2, 0), 0.5f, 1, 1);
    }

    private void OnDestroy()
    {
        _playerInput.OnPlayerJumped -= Jump;
    }
}
