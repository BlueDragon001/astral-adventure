using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class WizardInputHandler : MonoBehaviour
{

    private PlayerMovement playerMovement;
    private Vector2 mousePosition;
    PlayerAnimation playerAnimation;


    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimation>();


    }

    void Update()
    {
        var direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        SpiritMovement(direction);

    }




    void SpiritMovement(Vector3 direction)
    {
        playerMovement.SpiritMV(direction);
    }

    // private void MovementInput()
    // {


    //     var direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);



    //     if (playerMode == PlayerMode.Telekinesis)
    //     {


    //     }

    //     if (playerMode == PlayerMode.Flyable)
    //     {
    //         //Handle Flyable 
    //     }

    //     if (playerMode == PlayerMode.Spirit)
    //     {


    //     }
    // }



    public void MousePosition(InputAction.CallbackContext context) //Finds Mouse Position
    {

        mousePosition = context.ReadValue<Vector2>();

    }

    // public void OnLeftClick()
    // {
    //     FlyableObject flyableObjec = GetComponent<FlyableObject>();//Do not fucking touch it
    //     //ObjecSelector(selectableNo);
    //     flyableObjec.moveFlyable(mousePosition);

    // }



    // private void ObjecSelector(int selectableNo) //Selects the Flayable Objects
    // {
    //     RaycastHit hit;

    //     Ray ray = Camera.main.ScreenPointToRay(mousePosition); //Shoots ray toward mouse Position 
    //     if (Physics.Raycast(ray, out hit))
    //     {

    //         SelectedObjList = new List<GameObject>(GameObject.FindGameObjectsWithTag(staticString.tagSelected)); // Creates list of GameObjects with "Selected" tag
    //         if (hit.transform.CompareTag(staticString.tagSelectable)) //Compares the tags of gameobjects hitted camera ray with GameObjects in SelectedObjList
    //         {
    //             hit.transform.tag = staticString.tagSelected;
    //             if (SelectedObjList.Count >= selectableNo) //Discards the gameobjects if Exceeds certain Number
    //             {
    //                 var outofBoundObj = SelectedObjList[0];
    //                 outofBoundObj.tag = staticString.tagSelectable;

    //                 SelectedObjList.Remove(outofBoundObj);
    //             }

    //             return;
    //         }
    //         if (hit.transform.CompareTag(staticString.tagSelected)) //Discards the gameobjects when Slected twice
    //         {
    //             hit.transform.tag = staticString.tagSelectable;
    //             Rigidbody rigidbody = hit.transform.GetComponent<Rigidbody>();
    //             rigidbody.useGravity = true;
    //             SelectedObjList.Remove(hit.transform.gameObject);
    //         }
    //     }
    // }

}
