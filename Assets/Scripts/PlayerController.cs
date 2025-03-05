using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;

    private void Awake()
    {
        // PlayerInput コンポーネントから直接アクションを取得
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
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
            Debug.Log("jump");
        }

        // 移動処理
    }
}
