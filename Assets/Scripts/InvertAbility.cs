using UnityEngine;

public class InvertAbility : MonoBehaviour
{
    public GameObject normalSprite, invertedSprite;
    public bool inverted;

    public Collider2D normalGround, invertedGround;



    public Transform groundCheck;
    public float groundRadius;
    public LayerMask normalGroundLayer,invertedGroundLayer;

    public Transform DEBUG_POINT;
    void Start()
    {
        
    }


    void Update()
    {
        Collider2D hitGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, normalGroundLayer);
        Collider2D hitInvert  = Physics2D.OverlapCircle(groundCheck.position, groundRadius, invertedGroundLayer);

        if (!inverted)
        {
            DEBUG_POINT.position = transform.position - Vector3.up * 0.55f;
        }
        else
        {
            DEBUG_POINT.position = transform.position - Vector3.up * -0.55f;

        }

        if (Input.GetKeyDown(KeyCode.E) &&( hitGround || hitInvert))
        {
            inverted = !inverted;
            GetComponent<Rigidbody2D>().linearVelocityY = 0f;
            if (inverted)
            {
                transform.position -= Vector3.up * 0.55f;
            }
            else
            {
                transform.position -= Vector3.up * -0.55f;
            }
        }

        if (inverted)
        {
            GetComponent<Player>().gravityAxis = -1;
            normalSprite.SetActive(false);
            invertedSprite.SetActive(true);
            normalGround.enabled = false;
            invertedGround.enabled = true;
            transform.localScale = new Vector2(transform.localScale.x, -1f);
        }
        else
        {
            GetComponent<Player>().gravityAxis = 1;
            normalGround.enabled = true;
            invertedGround.enabled = false;
            normalSprite.SetActive(true);
            invertedSprite.SetActive(false);
            transform.localScale = new Vector2(transform.localScale.x, 1f);
        }
    }
}
