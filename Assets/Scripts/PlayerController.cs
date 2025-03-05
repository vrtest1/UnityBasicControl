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

    [SerializeField]
    private float rotationSpeed = 100f; // 回転速度

    private void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        float vertical = verticalAction.ReadValue<float>();
        Vector3 movement = new Vector3(move.x, vertical, move.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        if (jumpAction.triggered)
        {
            Debug.Log("jump");
        }

        // マウスの入力を取得して回転を適用
        float mouseX = Mouse.current.delta.x.ReadValue();

        float mouseY = Mouse.current.delta.y.ReadValue();

        Vector3 rotation = new Vector3(-mouseY, mouseX, 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation, Space.Self);
    }
}
