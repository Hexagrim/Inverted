using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;

    private Rigidbody2D rb;
    public bool isGrounded;
    float axis;


    public Transform groundCheck;
    public float groundRadius;
    public LayerMask groundLayer;

    public float gravityAxis;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(axis == 1f)
        {
            transform.localScale = new Vector3(1, transform.localScale.y);
        }
        else if (axis == -1f)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y);
        }


        if (Input.GetKeyDown(KeyCode.Space) &&isGrounded)
        {
            rb.linearVelocityY = jumpSpeed * gravityAxis;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        if (gravityAxis == 1)
        {
            if (rb.linearVelocityY > 0f)
            {
                rb.gravityScale = 2f;
            }
            else
            {
                rb.gravityScale = 4f;
            }
        }
        else
        {
            if (rb.linearVelocityY < 0f)
            {
                rb.gravityScale = -2f;
            }
            else
            {
                rb.gravityScale = -4f;
            }
        }
        if (isGrounded)
        {
            rb.linearDamping = 1f;
        }
        else
        {
            rb.linearDamping = 0f;
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocityX = speed;
            axis = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocityX = -speed;
            axis = -1f;
        }
        else
        {
            rb.linearVelocityX = 0f;
        }
        
    }


}
