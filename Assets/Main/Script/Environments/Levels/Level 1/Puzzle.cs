
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public Transform finalPosition, InititalPosition;


    [HideInInspector]
    public Transform tempPosition;
    void Awake()
    {

        tempPosition = InititalPosition;

    }


    void Update()
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


            if (tempPosition.position == InititalPosition.position)
            {
                tempPosition = finalPosition;

                return;
            }
            if (tempPosition.position == finalPosition.position)
            {
                tempPosition = InititalPosition;


                return;
            }




        }



    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(staticString.playerTag))
        {
            CharacterController characterController = other.GetComponent<CharacterController>();
            float input = Input.GetAxis("Vertical") + Input.GetAxis("Horizontal");
            if (input == 0)
            {
                Vector3 direction = (transform.position - other.transform.position).normalized;
                if (transform.position.y < other.transform.position.y)
                {
                    characterController.Move(direction * Time.deltaTime * 2.5f);
                    Debug.Log("Hello World");

                }

            }
        }
    }




}
