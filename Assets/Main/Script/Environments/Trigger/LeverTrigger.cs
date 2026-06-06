using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LeverTrigger : MonoBehaviour
{
    private bool isActive = false;
    public Button button;

    public GameObject leverHandle;

    public event Action triggerActivate, triggerNotActivate;
    [HideInInspector] public bool isInsideTrigger = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(staticString.spiritTag) || other.CompareTag(staticString.playerTag))
        {
            var localRotX = leverHandle.transform.rotation.x;
            var localRotY = leverHandle.transform.rotation.y;
            isInsideTrigger = true;

            // if (other.CompareTag(staticString.playerTag))
            // {
            //     var playerManager = other.gameObject.GetComponent<PlayerManager>(); playerManager.insideTrigger = true;
            // }

            // button.onClick.AddListener(() =>
            // {
            //     if (!isActive)
            //     {
            //         StartCoroutine(RotateObject(Quaternion.Euler(localRotX, localRotY, 40f), Quaternion.Euler(localRotX, localRotY, -40f)));
            //         triggerActivate?.Invoke();
            //         isActive = true;
            //     }
            //     else
            //     {
            //         StartCoroutine(RotateObject(Quaternion.Euler(localRotX, localRotY, -40f), Quaternion.Euler(localRotX, localRotY, 40f)));
            //         triggerNotActivate?.Invoke();
            //         isActive = false;
            //     }
            //     return;
            // });

            if (Input.GetKeyDown(KeyCode.Y) && !isActive)
            {
                StartCoroutine(RotateObject(Quaternion.Euler(localRotX, localRotY, 40f), Quaternion.Euler(localRotX, localRotY, -40f)));
                triggerActivate?.Invoke();
                isActive = true;
            }
            else if (Input.GetKeyDown(KeyCode.Y) && isActive)
            {
                StartCoroutine(RotateObject(Quaternion.Euler(localRotX, localRotY, -40f), Quaternion.Euler(localRotX, localRotY, 40f)));
                triggerNotActivate?.Invoke();
                isActive = false;

            }



        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(staticString.playerTag))
        {
            var playerManager = other.gameObject.GetComponent<PlayerManager>(); playerManager.insideTrigger = true;
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
