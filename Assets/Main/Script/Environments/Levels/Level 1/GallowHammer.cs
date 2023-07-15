using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GallowHammer : MonoBehaviour
{
    public LeverTrigger leverTrigger;
    public float swingSpeed = 20f;
    public float swingAngle = 90f;

    private float currentAngle = 0f;
    private bool isSwingingForward = true;

    public bool swingEnabled = true;

    // void Start()
    // {

    //     leverTrigger.triggerActivate += OntriggerActive;
    //     leverTrigger.triggerNotActivate += OntriggerNotActive;
    // }

    // void OntriggerActive()
    // {
    //     swingEnabled = false;
    // }

    // void OntriggerNotActive()
    // {
    //     swingEnabled = true;
    // }

    void Update()
    {
        float angleDelta = swingSpeed;
        if (swingEnabled)
        {
            if (isSwingingForward)
            {
                currentAngle += angleDelta * Time.deltaTime;
                if (currentAngle > swingAngle)
                {
                    currentAngle = swingAngle;
                    isSwingingForward = false;
                }
            }
            else
            {
                currentAngle -= angleDelta * Time.deltaTime;
                if (currentAngle < -swingAngle)
                {
                    currentAngle = -swingAngle;
                    isSwingingForward = true;
                }
            }

            transform.rotation = Quaternion.AngleAxis(currentAngle, Vector3.forward);
        }

    }

    // void Update()
    // {
    //     float angleDelta = swingSpeed;
    //     float targetAngle = 0f;

    //     if (swingEnabled)
    //     {
    //         if (isSwingingForward)
    //         {
    //             targetAngle = swingAngle;
    //             if (currentAngle > targetAngle)
    //             {
    //                 currentAngle -= angleDelta * Time.deltaTime;
    //                 if (currentAngle < targetAngle)
    //                 {
    //                     currentAngle = targetAngle;
    //                     isSwingingForward = false;
    //                 }
    //             }
    //         }
    //         else
    //         {
    //             targetAngle = -swingAngle;
    //             if (currentAngle < targetAngle)
    //             {
    //                 currentAngle += angleDelta * Time.deltaTime;
    //                 if (currentAngle > targetAngle)
    //                 {
    //                     currentAngle = targetAngle;
    //                     isSwingingForward = true;
    //                 }
    //             }
    //         }

    //         // Apply bicubic interpolation to smooth out the rotation
    //         float t = Mathf.InverseLerp(-swingAngle, swingAngle, currentAngle);
    //         float smoothedT = UnityCSharpExtension.BicubicInterpolation(t);
    //         currentAngle = Mathf.Lerp(-swingAngle, swingAngle, smoothedT);

    //         transform.rotation = Quaternion.AngleAxis(currentAngle, Vector3.forward);
    //     }
    // }

}



