using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEngine : MonoBehaviour
{
    public Transform initialPosition;
    public Transform finalPosition;
    private Vector3 movementDirection;
    private Vector3 previousPlatformPosition = Vector3.zero;
    [HideInInspector]
    public Transform tempPosition;

    private void Start()
    {
        tempPosition = initialPosition;
        movementDirection = (finalPosition.position - initialPosition.position).normalized;
    }

    private void Update()
    {
        Idle(tempPosition);

    }

    public void Idle(Transform tempPosition)
    {
        DirecionHandler();
        transform.position =
        Vector3.MoveTowards(transform.position, tempPosition.position, Time.deltaTime * 0.5f);
    }


    private void DirecionHandler()
    {
        float distance = Vector3.Distance(transform.position, tempPosition.position);


        if (distance <= 0.1f)
        {


            if (tempPosition.position == initialPosition.position)
            {
                tempPosition = finalPosition;

                return;
            }
            if (tempPosition.position == finalPosition.position)
            {
                tempPosition = initialPosition;


                return;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(staticString.playerTag))
        {
            previousPlatformPosition = transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(staticString.playerTag))
        {
            CharacterController characterController = other.GetComponent<CharacterController>();
            Vector3 platformMovement = transform.position - previousPlatformPosition;
            characterController.Move(platformMovement);
            previousPlatformPosition = transform.position;
        }
    }


}
