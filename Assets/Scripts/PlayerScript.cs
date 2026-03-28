using UnityEditor.AnimatedValues;
using UnityEngine;

public class MainCode : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody2D playerRigidbody;
    public int throwForce;
    
    
    public bool isGrounded;
    public bool canDoubleJump;

    public float jumpForce = 5f;


    void Start()
    {
        
    }


    void Update()
    {



        if (playerTransform.position.x > -9.5)
        {
            if (Input.GetKey(KeyCode.A))
            {
                playerTransform.Translate(-2f * Time.deltaTime, 0, 0);
            }
        }

        if (playerTransform.position.x < 61)
        {
            if (Input.GetKey(KeyCode.D))
            {
                playerTransform.Translate(2f * Time.deltaTime, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isGrounded)
            {
                playerRigidbody.AddForce(playerTransform.up * throwForce, ForceMode2D.Impulse);
                canDoubleJump = true;
            }

            else if (canDoubleJump)
            {
                playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocity.x, 0 );
                canDoubleJump = false;
            }
            
        }
    }
}
