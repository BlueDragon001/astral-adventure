using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{


    private PlayerMovement playerMovement;
    private FlyableObject flyableObject;
    private Vector2 mousePosition;
    //    public enum PlayerMode { Spirit, Telekinesis, Flyable } //Defines Charecter with different Atrributes

    //  public PlayerMode playerMode; //Chooses charecter of Specfic Attribute

    [SerializeField]
    private int selectableNo; //Number of 


    List<GameObject> SelectedObjList = new List<GameObject>();


    public bool isAlive = true;

    PlayerAnimation playerAnimation;

    private Attack attack;
    public AudioSource walkSFX;
    public AudioSource jumpSFX;

    public bool isJumping = false;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        flyableObject = GetComponent<FlyableObject>();
        playerAnimation = GetComponent<PlayerAnimation>();
        attack = GetComponent<Attack>();


    }

    void Start()
    {
        if (!transform.CompareTag(staticString.spiritTag))
        {
            float SFXVolume = UnityCSharpExtension.InterpolateValue(staticMenuData.masterVolume * staticMenuData.sfxVolume, 0f, 100f * 100f);
            walkSFX.volume = SFXVolume/3;
            jumpSFX.volume = SFXVolume;
        }

    }

    void Update()
    {


        if (isAlive)
        {
            var direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            TelekinesisMovement(direction);
            if (direction.magnitude != 0 && !transform.CompareTag(staticString.spiritTag) && !walkSFX.isPlaying) walkSFX.Play();

        }




    }



    void TelekinesisMovement(Vector3 direction)
    {
        playerMovement.TelekineticsMV(direction);
        //  flyableObject.moveFlyable(direction * Time.deltaTime);
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMovement.Jump();
            jumpSFX.Play();
            
        }
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



    // public void MousePosition(InputAction.CallbackContext context) //Finds Mouse Position
    // {

    //     mousePosition = context.ReadValue<Vector2>();

    // }

    public void OnLeftClick()
    {
        // FlyableObject flyableObjec = GetComponent<FlyableObject>();//Do not fucking touch it
        // ObjecSelector(selectableNo);
        // flyableObjec.moveFlyable(mousePosition);

        if (isAlive)
        {
            attack.EnemyAttack();

        }

    }


    private void ObjecSelector(int selectableNo) //Selects the Flayable Objects
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition); //Shoots ray toward mouse Position 
        if (Physics.Raycast(ray, out hit))
        {

            SelectedObjList = new List<GameObject>(GameObject.FindGameObjectsWithTag(staticString.tagSelected)); // Creates list of GameObjects with "Selected" tag
            if (hit.transform.CompareTag(staticString.tagSelectable)) //Compares the tags of gameobjects hitted camera ray with GameObjects in SelectedObjList
            {
                hit.transform.tag = staticString.tagSelected;
                if (SelectedObjList.Count >= selectableNo) //Discards the gameobjects if Exceeds certain Number
                {
                    var outofBoundObj = SelectedObjList[0];
                    outofBoundObj.tag = staticString.tagSelectable;

                    SelectedObjList.Remove(outofBoundObj);
                }

                return;
            }
            if (hit.transform.CompareTag(staticString.tagSelected)) //Discards the gameobjects when Slected twice
            {
                hit.transform.tag = staticString.tagSelectable;
                Rigidbody rigidbody = hit.transform.GetComponent<Rigidbody>();
                rigidbody.useGravity = true;
                SelectedObjList.Remove(hit.transform.gameObject);
            }
        }
    }

}
