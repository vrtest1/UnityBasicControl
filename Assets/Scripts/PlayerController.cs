using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction verticalAction;
    private InputAction sprintAction;

    private bool mouseRot = false;
    private void Awake()
    {
        // PlayerInput コンポーネントから直接アクションを取得
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        verticalAction = playerInput.actions["Vertical"];
        sprintAction = playerInput.actions["Sprint"];
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        verticalAction.Enable();
        sprintAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        verticalAction.Disable();
        sprintAction.Disable();
    }

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float sprintMultiplier = 2f;
    private float rotationSpeed = 30f; // 回転速度

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseRot = !mouseRot;
        }

        Vector2 move = moveAction.ReadValue<Vector2>();
        float vertical = verticalAction.ReadValue<float>();
        float currentSpeed = moveSpeed;
        if (sprintAction.ReadValue<float>() > 0)
        {
            currentSpeed *= sprintMultiplier;
        }
        Vector3 movement = new Vector3(move.x, vertical, move.y) * currentSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        if (jumpAction.triggered)
        {
            Debug.Log("jump");
        }

        if (mouseRot)
        {
            // マウスの入力を取得して回転を適用
            float mouseX = Mouse.current.delta.x.ReadValue();
            float mouseY = Mouse.current.delta.y.ReadValue();

            Vector3 rotation = new Vector3(-mouseY, mouseX, 0) * rotationSpeed * Time.deltaTime;
            //transform.Rotate(rotation, Space.Self);
            // X軸回転（縦方向）
            transform.Rotate(Vector3.right, -mouseY * rotationSpeed * Time.deltaTime, Space.Self);

            // Y軸回転（横方向）
            transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime, Space.World);
        }


    }
}
