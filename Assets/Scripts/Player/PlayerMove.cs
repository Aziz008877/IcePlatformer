using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMove : MonoBehaviour, IMovable
{
    [SerializeField] private float _baseSpeed, _runningSpeed, _walkingSpeed;
    private PlayerInput _playerInput;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.OnPlayerMoved += Move;
    }
    
    public void Move(Vector2 moveVector)
    {
        transform.Translate(moveVector * _baseSpeed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        _playerInput.OnPlayerMoved -= Move;
    }
}
