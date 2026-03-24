using UnityEditor.AnimatedValues;
using UnityEngine;

public class MainCode : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody2D playerRigidbody;
    public int throwForce;
    void Start()
    {
        
    }


    void Update()
    {
        if(playerTransform.position.x > -9.5)
        {
            if(Input.GetKey(KeyCode.A))
            {
            playerTransform.Translate(-Time.deltaTime, 0, 0);
            }
        }

        


        if(playerTransform.position.x < 61)
        {  
            if (Input.GetKey(KeyCode.D))
            {
            playerTransform.Translate(Time.deltaTime, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Hi");
            playerRigidbody.AddForce(playerTransform.up * throwForce, ForceMode2D.Impulse);
        }

        

      

    }
}
