using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempTarget : MonoBehaviour
{

    [SerializeField]
    private AnimationCurve curve;
    [SerializeField, Range(1, 10)]
    private int swingAmplitude;

    void Update()
    {
        
        
    }

    public void Animation(){
        gameObject.transform.Translate(new Vector3(0, curve.Evaluate(Time.time) / swingAmplitude, 0));
    }

    public void Attack(GameObject Target){
        gameObject.transform.Translate(Target.transform.position);
    }
    
}
