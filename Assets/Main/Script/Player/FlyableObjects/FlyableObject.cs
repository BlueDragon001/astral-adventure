using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class FlyableObject : MonoBehaviour
{
    [SerializeField]
    private int attackSpeed = 10;

    [SerializeField]
    private int movementSpeed = 1;
    

    List<GameObject> FindFlyable()
    {
        List<GameObject> selectedObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag(staticString.tagSelected));
        return selectedObjects;
        
    }

    

    public void KinesisAttack(Vector3 attackableObjPos)
    {
        if (FindFlyable().Count > 0)
        {
            foreach (GameObject flyableObject in FindFlyable())
            {
                Rigidbody rigidbody = flyableObject.GetComponent<Rigidbody>();
                rigidbody.useGravity = false;

                Vector3 direction = rigidbody.position - attackableObjPos;

                rigidbody.AddForce(direction.normalized * Time.deltaTime * attackSpeed, ForceMode.Impulse);
            }
        }
    }

    public void moveFlyable(Vector3 direction)
    {
        if (FindFlyable().Count > 0){
            foreach(GameObject flyableObject in FindFlyable()){
                Rigidbody rigidbody = flyableObject.GetComponent<Rigidbody>();
                rigidbody.useGravity = false;
                rigidbody.velocity = direction * Time.deltaTime * movementSpeed;

            }
        }
    }
}
