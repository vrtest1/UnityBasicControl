using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;

    private void Awake()
    {
        playerInput = new PlayerInput();
        moveAction = playerInput.Player.Move;
        jumpAction = playerInput.Player.Jump;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }

    private void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        if (jumpAction.triggered)
        {
            // ジャンプ処理
        }

        // 移動処理
    }
}
