using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class PlayerPhysicsMovement : MonoBehaviour
{
    private Rigidbody rb;

    public int movementSpeed;
    public int jumpSpeed;
  
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // var direction = new Vector3();
        // direction.x = Input.GetAxis("Horizontal") * Time.deltaTime;
        // TelekineticsMV(direction);

        // if (Input.GetKeyDown(KeyCode.Space))
        // {

        //     Jump();
        // }

        // if (Input.GetMouseButtonDown(0))
        // {
        //     var mousePosition = Input.mousePosition;
           
        // }
    }

    public void TelekineticsMV(Vector3 direction)
    {
        rb.AddForce( direction.normalized * movementSpeed * Time.deltaTime, ForceMode.Impulse);

    }

    public void Jump()
    {
        if (rb.velocity.y == 0)
        {
            rb.AddForce( Vector3.up * jumpSpeed * Time.deltaTime);

        }


    }

    


}
