using UnityEngine;

public class InvertAbility : MonoBehaviour
{
    public GameObject normalSprite, invertedSprite;
    public bool inverted;

    public Collider2D normalGround, invertedGround;



    public Transform groundCheck;
    public float groundRadius;
    public LayerMask normalGroundLayer,invertedGroundLayer;
    void Start()
    {
        
    }


    void Update()
    {
        bool NormalGroundTouch  = Physics2D.OverlapCircle(groundCheck.position, groundRadius, normalGroundLayer);
        bool InvertGroundTouch  = Physics2D.OverlapCircle(groundCheck.position, groundRadius, invertedGroundLayer);


        if (Input.GetKeyDown(KeyCode.E) &&( NormalGroundTouch || InvertGroundTouch))
        {
            inverted = !inverted;
        }

        if (inverted)
        {
            GetComponent<Player>().gravityAxis = -1;
            normalSprite.SetActive(false);
            invertedSprite.SetActive(true);
            normalGround.enabled = false;
            invertedGround.enabled = true;
        }
        else
        {
            GetComponent<Player>().gravityAxis = 1;
            normalGround.enabled = true;
            invertedGround.enabled = false;
            normalSprite.SetActive(true);
            invertedSprite.SetActive(false);
        }
    }
}
