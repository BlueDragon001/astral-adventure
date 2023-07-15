using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    private CharacterController characterController;

    public Transform finalPosition;
    public Vector3 initialPosition;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = -transform.position + new Vector3(finalPosition.position.x, transform.position.y, finalPosition.position.z);
        
       

        characterController.Move(direction);
         Debug.Log(direction);
    }
}
