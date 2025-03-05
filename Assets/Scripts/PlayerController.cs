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

    [SerializeField]
    private float moveSpeed = 5f;

    private void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(move.x, 0, move.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        if (jumpAction.triggered)
        {
            // ジャンプ処理
            Debug.Log("jump");
        }
    }
}
