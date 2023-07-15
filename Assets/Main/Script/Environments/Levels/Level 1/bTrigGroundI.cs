using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bTrigGroundI : MonoBehaviour
{
    LeverTrigger leverTrigger;
    public Transform Lift;

    public Transform finalPosition;
    private Vector3 initialPosition;
    void Start()
    {
        leverTrigger = GetComponent<LeverTrigger>();
        leverTrigger.triggerActivate += OnTriggerActive;
        initialPosition = transform.position;
        
        
    }

    void OnTriggerActive()
    {
        StartCoroutine(TriggerActive(initialPosition, finalPosition));
        
    }

    IEnumerator TriggerActive(Vector3 initialPosition, Transform finalPosition)
    {
        while (Lift.transform.position != finalPosition.position){
            
            Lift.transform.position = Vector3.MoveTowards(Lift.transform.position, finalPosition.position, Time.deltaTime * 0.2f);
            yield return null;
        }
    }
}
