using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(Animator))]
public class PlayerAnimate : MonoBehaviour
{
    private Animator _animator;
    private PlayerInput _playerInput;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        
        _playerInput.OnPlayerMoved += Running;
        _playerInput.OnPlayerJumped += Jump;
    }

    private void BoolState(string animationName, bool state)
    {
        _animator.SetBool(animationName, state);
    }

    private void TriggerState(string triggerName)
    {
        _animator.SetTrigger(triggerName);
    }

    private void Running(Vector2 moveDirection)
    {
        if (moveDirection != Vector2.zero)
        {
            BoolState("IsWalking", true);
        }
        else
        {
            BoolState("IsWalking", false);
        }
    }

    private void Jump()
    {
        TriggerState("IsJumping");
    }

    private void OnDestroy()
    {
        _playerInput.OnPlayerMoved -= Running;
    }
}
