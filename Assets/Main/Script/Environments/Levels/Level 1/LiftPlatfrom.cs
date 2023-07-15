using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftPlatfrom : MonoBehaviour
{
    LeverTrigger leverTrigger;
    public Transform Lift;

    public Transform finalPosition;
    private Vector3 initialPosition;

    public GameObject player;
    private InputHandler inputHandler;
    void Start()
    {
        leverTrigger = GetComponent<LeverTrigger>();
        leverTrigger.triggerActivate += OnTriggerActive;
        initialPosition = transform.position;




    }

    void OnTriggerActive()
    {
        inputHandler = player.GetComponent<InputHandler>();
        StartCoroutine(TriggerActive(initialPosition, finalPosition));


    }

    IEnumerator TriggerActive(Vector3 initialPosition, Transform finalPosition)
    {
        while (Lift.transform.position != finalPosition.position)
        {

            if (inputHandler.isAlive == true)
            {
                Lift.transform.position = Vector3.MoveTowards(Lift.transform.position, finalPosition.position, Time.deltaTime * 2f);
            }
            yield return null;
        }
    }
}
