using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    void OnCollisionrEnter(Collider other)
    {
        Debug.Log("Trigger Enter :" + other.transform.tag);


    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger Stay :" + other.transform.tag);
    }

    void OnTriggerExit(Collider other){
        Debug.Log("Trigger Exit :" + other.transform.tag);
    }
}
