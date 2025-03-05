using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction verticalAction;

    private void Awake()
    {
        // PlayerInput コンポーネントから直接アクションを取得
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        verticalAction = playerInput.actions["Vertical"];
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        verticalAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        verticalAction.Disable();
    }

    [SerializeField]
    private float moveSpeed = 5f;

    private void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        float vertical = verticalAction.ReadValue<float>();
        Vector3 movement = new Vector3(move.x, vertical, move.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        if (jumpAction.triggered)
        {
            // ジャンプ処理
            Debug.Log("jump");
        }
    }
}
