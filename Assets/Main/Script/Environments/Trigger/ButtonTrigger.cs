using System;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public event Action triggerActivate;
    public GameObject button;
    bool isActive = false;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(staticString.playerTag))
        {
            var renderer = button.GetComponent<Renderer>();

            if (Input.GetKey(KeyCode.Y) && !isActive)
            {
                isActive = true;
                renderer.material.SetColor("_Color", Color.green);
                if (triggerActivate != null) triggerActivate();
                return;
            }
            if (Input.GetKey(KeyCode.Y) && isActive)
            {
                isActive = false;
                
                renderer.material.SetColor("_Color", Color.red);
                return;
            }
        }
    }
}
