using UnityEditor.AnimatedValues;
using UnityEngine;

public class MainCode : MonoBehaviour
{

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private Animator playerAnimator;
    
    public Rigidbody2D playerRigidbody;
    public int throwForce;
    
    
    public bool isGrounded;
    public bool canDoubleJump;
    public bool canMove = true;


    void Start()
    {
        
    }

    void Update()
    {
        if (!canMove) return;
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A))
                moveInput = -0.7f;          
        else if (Input.GetKey(KeyCode.D))           
                moveInput = 0.7f;

        playerRigidbody.linearVelocity = new Vector2 (moveInput * 5f, playerRigidbody.linearVelocity.y);   

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        if (isGrounded)
        {
            canDoubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {         
            if (isGrounded)
            {
                playerRigidbody.AddForce(Vector2.up * throwForce, ForceMode2D.Impulse);
                canDoubleJump = true;
            }

            else if (canDoubleJump)
            {
                playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocity.x, 0 );
                playerRigidbody.AddForce(Vector2.up * throwForce,ForceMode2D.Impulse);
                canDoubleJump = false;
            }
            
        }

        Vector2 pos = playerRigidbody.position;
        {
            if (pos.x <-30f)
            {
                pos.x = -30f;
                playerRigidbody.position = pos;
            }
        }

    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerReachTheEnd(other);
    }

    void PlayerReachTheEnd(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            GameManager gm = FindFirstObjectByType<GameManager>();

            gm.GameOver();

            Camera cam = Camera.main;
            if (cam != null)
            {
                cam.transform.parent = null;
            }

            GetComponent<MainCode>().DisablePlayer();
            
        }
    }

    public void DisablePlayer()
    {
        canMove = false;

        playerRigidbody.linearVelocity = Vector2.zero;
        playerRigidbody.simulated = false;
    }
}
