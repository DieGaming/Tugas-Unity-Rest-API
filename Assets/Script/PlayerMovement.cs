using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    Rigidbody2D rb;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public Vector2 moveDir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
        }

        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
        }
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(moveDir.x * MoveSpeed, moveDir.y * MoveSpeed);
    }
}
