using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;

    private Rigidbody2D rb;
    private float halfWidth;
    [SerializeField] private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        halfWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        moveInput = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                moveInput = -1f;

            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                moveInput = 1f;
        }
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + Vector2.right * moveInput * speed * Time.fixedDeltaTime;

        float clampedX = Mathf.Clamp(
            newPosition.x,
            -halfWidth,
            halfWidth
        );

        rb.MovePosition(new Vector2(clampedX, rb.position.y));
    }
}