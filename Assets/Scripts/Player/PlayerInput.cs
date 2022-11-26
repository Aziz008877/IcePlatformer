using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector2> OnPlayerMoved;
    public event Action OnPlayerJumped;
    private bool _isJumping;
    void Update()
    {
        MoveInput();
        JumpInput();
    }

    private void MoveInput()
    {
        float horMove = Input.GetAxis("Horizontal");
        OnPlayerMoved?.Invoke(new Vector2(horMove, 0));
    }

    private async void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            _isJumping = true;
            OnPlayerJumped?.Invoke();
            await Task.Delay(1000);
            _isJumping = false;
        }
    }
}
