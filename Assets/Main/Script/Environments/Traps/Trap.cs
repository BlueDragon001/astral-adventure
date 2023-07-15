using System;
using UnityEngine;

public class Trap : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(staticString.playerTag))
        {
            var playerManager = other.GetComponent<PlayerManager>();
            playerManager.isAlive = false;
        }
    }
}
