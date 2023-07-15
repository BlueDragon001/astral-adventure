using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class treeMonster : MonoBehaviour
{

    public GameObject Player;


    public List<GameObject> targets;

    public List<Vector3> targetPosition;

    // [SerializeField, Range(10, 15)]
    // int attDistance = 10;

    [SerializeField, Range(0, 1)]
    float AttackSpeed = 0;

    [SerializeField, Range(5, 15)]
    int AttackRange = 5;

    void Start()
    {



        targetPosition = new List<Vector3>();
        foreach (GameObject item in targets)
        {
            targetPosition.Add(item.transform.position);

        }
    }


    void Update()
    {
        var distance = Vector3.Distance(this.gameObject.transform.position, Player.transform.position);

        if (distance < AttackRange)
        {
            Attack();
        }
        else
        {
            Animation();
        }

    }

    void Attack()
    {
        //It's Chooses Random Branch but it's not used right now.
        float Oscillator = 0;
        Oscillator = Time.fixedTime * AttackSpeed;
        var positionRandom = Random.Range(0, targets.Count);

        targets[positionRandom].transform.position = Vector3.Lerp(Player.transform.position, targetPosition[positionRandom],
        Mathf.Pow(Mathf.Sin(Oscillator), 2f));


    }

    void Animation()
    {
        for (int i = 0; i <targets.Count; i++)
        {
            targets[i].transform.position = Vector3.Lerp(targetPosition[i] + Vector3.up*2, targetPosition[i],
        Mathf.Pow(Mathf.Sin(Time.fixedTime * AttackSpeed), 2f));

        }

    }

    



}
