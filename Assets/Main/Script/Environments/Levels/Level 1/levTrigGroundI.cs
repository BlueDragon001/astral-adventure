using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levTrigGroundI : MonoBehaviour
{
    LeverTrigger leverTrigger;
    public Transform laserHeight;
    public Transform Gate;
    void Start()
    {
        leverTrigger = GetComponent<LeverTrigger>();
        leverTrigger.triggerActivate += OnTriggerActive;
        leverTrigger.triggerNotActivate += OnTriggerNotActive;
        StartCoroutine(OnActive(false));
    }

    void OnTriggerActive()
    {
        StartCoroutine(OnActive(true));
    }

    void OnTriggerNotActive()
    {
         StartCoroutine(OnActive(false));
    }

    IEnumerator OnActive(bool isActive)
    {
        float t = 0;
        float laserHeightStart = 0;
        float laserHeightEnd = 0f;
        float gateHeightStart =  0f;
        float gateHeightEnd =  0f;
        if(isActive){
            laserHeightEnd = 0.2799999f;
            gateHeightStart = 1;
        }
        else{
            laserHeightStart = 0.2799999f;
            gateHeightEnd = 1;
            
        }
        while (t < 1f)
        {
            t += Time.deltaTime;
            laserHeight.localScale = new Vector3(laserHeight.localScale.x, Mathf.Lerp(laserHeightStart, laserHeightEnd, t), laserHeight.localScale.z);
            Gate.localScale = new Vector3(Gate.localScale.x, Mathf.Lerp(gateHeightStart, gateHeightEnd, t), Gate.localScale.z);
            yield return null;
        }
    }

}
