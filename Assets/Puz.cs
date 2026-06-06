using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puz : MonoBehaviour
{
    void OnTriggerStay(Collider other){
        if(other.CompareTag(staticString.playerTag)){
            other.transform.SetParent(transform);
        }
    }
}
