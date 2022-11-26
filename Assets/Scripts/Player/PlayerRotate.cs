using System;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerRotate : MonoBehaviour
{
    private PlayerInput _playerInput;
    
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.OnPlayerMoved += Rotate;
    }

    private void Rotate(Vector2 moveDirection)
    {
        if (moveDirection != Vector2.zero)
        {
            if (moveDirection.x < 0)
            {
                transform.DOScaleX(-1, 0);
            }
            else
            {
                transform.DOScaleX(1, 0);
            }
        }
    }

    private void OnDestroy()
    {
        _playerInput.OnPlayerMoved -= Rotate;
    }
}
