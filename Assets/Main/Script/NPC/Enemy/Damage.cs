using UnityEngine;

public class Damage : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(staticString.playerTag))
        {
            PlayerManager playerManager = other.transform.GetComponent<PlayerManager>();
            playerManager.isAlive = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(staticString.playerTag))
        {
            PlayerManager playerManager = collision.transform.GetComponent<PlayerManager>();
            playerManager.isAlive = false;
        }
    }
}
