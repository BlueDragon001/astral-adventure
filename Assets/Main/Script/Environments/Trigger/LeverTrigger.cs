using System;
using System.Collections;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    private bool isActive = false;


    public GameObject leverHandle;

    public event Action triggerActivate, triggerNotActivate;
    private void OnTriggerStay(Collider other)
    {
        if ( other.CompareTag(staticString.spiritTag) || other.CompareTag(staticString.playerTag))
        {
            var localRotX = leverHandle.transform.rotation.x;
            var localRotY = leverHandle.transform.rotation.y;
            if (Input.GetKeyDown(KeyCode.Y) && !isActive)
            {
                StartCoroutine(RotateObject(Quaternion.Euler(localRotX, localRotY, 40f), Quaternion.Euler(localRotX, localRotY, -40f)));
                if(triggerActivate != null) triggerActivate();
                isActive = true;
            }
            else if (Input.GetKeyDown(KeyCode.Y) && isActive)
            {
                StartCoroutine(RotateObject(Quaternion.Euler(localRotX, localRotY, -40f), Quaternion.Euler(localRotX, localRotY, 40f)));
                if(triggerNotActivate != null) triggerNotActivate();
                isActive = false;

            }
        }

    }





    private IEnumerator RotateObject(Quaternion endRotation, Quaternion startRotation)
    {
        //Quaternion startRotation = transform.localRotation;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / 0.1f; // rotate over 0.5 seconds
            leverHandle.transform.rotation = Quaternion.Lerp(endRotation, startRotation, t);
            yield return null;
        }
        

    }
}
