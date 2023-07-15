
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    private CharacterController playerController;
    public LayerMask groundLayer;

    public GameObject groundCheck;

    [SerializeField]
    private float playerSpeed = 10;

    [SerializeField]
    private float jumpHeight = 5;

    [SerializeField]
    private int absGravity = -10;

    float gravDirection;

    public Vector3 movementDirection;

    private PlayerAnimation playerAnimation;


    public AudioSource jumpSFX;







    void Awake()
    {
        playerController = GetComponent<CharacterController>();
        playerAnimation = GetComponent<PlayerAnimation>();

        if (!transform.CompareTag(staticString.spiritTag))
        {
            float sfxVolume = UnityCSharpExtension.InterpolateValue(staticMenuData.masterVolume * staticMenuData.sfxVolume, 0f, 10000f);
            jumpSFX.volume = sfxVolume;
        }
    }

    void Update()
    {


        //TelekineticsMV(movementDirection);

    }
    public void TelekineticsMV(Vector3 direction)
    {
        gravity(groundCheck);



        playerController.Move(-direction * playerSpeed * Time.deltaTime);
        playerAnimation.Locomotion(direction);


    }


    public void SpiritMV(Vector3 direction)
    {
        direction.x = -direction.x;
        if (direction.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, -(transform.rotation.y + 90), 0);

        }
        if (direction.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, -(transform.rotation.y + 270), 0);
        }
        transform.Translate(direction * playerSpeed * Time.deltaTime, Space.World);
    }

    public void Jump()
    {
        if (Physics.CheckSphere(groundCheck.transform.position, 0.2f, groundLayer))
        {
            gravDirection = Mathf.Sqrt(jumpHeight * -2f * absGravity);
            playerAnimation.JumpAnimation(true);
            jumpSFX.Play();

        }



    }

    void gravity(GameObject groundCheck)
    {

        if (Physics.CheckSphere(groundCheck.transform.position, 0.2f, groundLayer) && gravDirection < 0)
        {
            gravDirection = -2f;
        }

        gravDirection += absGravity * Time.deltaTime;

        playerController.Move(new Vector3(0, gravDirection, 0) * Time.deltaTime);

        if (!Physics.CheckSphere(groundCheck.transform.position, 0.2f, groundLayer)) playerAnimation.JumpAnimation(false);


    }



}
