using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector2> OnPlayerMoved;
    void Update()
    {
        MoveInput();
    }

    private void MoveInput()
    {
        float horMove = Input.GetAxis("Horizontal");
        OnPlayerMoved?.Invoke(new Vector2(horMove, 0));
    }
}
