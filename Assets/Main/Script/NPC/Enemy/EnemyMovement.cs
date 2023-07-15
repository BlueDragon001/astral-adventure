using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject Player;
    public Transform enemyEye;
    private Transform playerBeacon;

    private GameObject player;
    private EnemyAnimation enemyAnimation;

    public Transform finalPosition, InititalPosition;


    [HideInInspector]
    public Transform tempPosition;

    private bool isPlayer = false;


    [SerializeField] private float AttackDistance = 0.4f;

    CharacterController characterController;

    public LayerMask groundLayer;

    public GameObject groundCheck;
    private int absGravity = -10;

    float gravDirection;
    public int playerDetectionRange = 10;

    public LayerMask enemyLayer;

    public Transform areaScanner;




    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(staticString.playerTag);
        enemyAnimation = GetComponent<EnemyAnimation>();
        tempPosition = InititalPosition;
        characterController = GetComponent<CharacterController>();

    }

    void Start()
    {
        playerBeacon = GameObject.FindGameObjectWithTag(staticString.playerBeacon).transform;
    }




    // void PlayerDetector()
    // {
    //     RaycastHit hit;
    //     Vector3 playerDirection = (playerBeacon.transform.position - enemyEye.position).normalized;
    //     Ray ray = new Ray(enemyEye.position, playerDirection);
    //     if (playerDirection.x > 0 && !isPlayer)
    //     {

    //         if (transform.rotation.eulerAngles.y > 0)
    //         {
    //             if (Physics.Raycast(ray, out hit, playerDetectionRange))
    //             {
    //                 if (hit.transform.CompareTag(staticString.playerBeacon) || hit.transform.CompareTag(staticString.playerTag))
    //                 {
    //                     isPlayer = true;

    //                 }
    //             }
    //         }
    //     }
    //     else
    //     {
    //         if (transform.rotation.eulerAngles.y < 0)
    //         {
    //             if (Physics.Raycast(ray, out hit, playerDetectionRange))
    //             {
    //                 if (hit.transform.CompareTag(staticString.playerBeacon) || hit.transform.CompareTag(staticString.playerTag))
    //                 {
    //                     isPlayer = true;
    //                 }
    //             }
    //         }
    //     }

    // }

    void PlayerDetector()
    {
        RaycastHit hit;
        Vector3 playerDirection = (playerBeacon.transform.position - enemyEye.position).normalized;
        Ray ray = new Ray(enemyEye.position, playerDirection);

        if (Vector3.Dot(transform.forward, playerDirection) > 0 && !isPlayer)
        {
            if (Physics.Raycast(ray, out hit, playerDetectionRange))
            {
                if (hit.transform.CompareTag(staticString.playerBeacon) || hit.transform.CompareTag(staticString.playerTag))
                {
                    isPlayer = true;
                }
            }
        }
    }


    public void Movement()
    {
        gravity();
        if (!isPlayer)
        {
            Idle(tempPosition);
            PlayerDetector();
            enemyAnimation.Attack(false);
        }
        else
        {

            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance >= AttackDistance && distance < playerDetectionRange)
            {
                TowardPlayer(player.transform);
            }
            if (distance >= playerDetectionRange)
            {
                isPlayer = false;
            }

            if (distance <= AttackDistance)
            {
                enemyAnimation.Attack(true);
            }
        }



    }



    public void Idle(Transform tempPosition)
    {
        DirecionHandler();
        //     transform.position =
        //    Vector3.MoveTowards(transform.position, new Vector3(tempPosition.position.x, PositionOffset().y, tempPosition.position.z), Time.deltaTime / 2);
        Vector3 direction = (-transform.position + new Vector3(tempPosition.position.x, transform.position.y, tempPosition.position.z)).normalized;
        characterController.Move(direction * 0.4f * Time.deltaTime);


    }

    public void TowardPlayer(Transform playerPosition)
    {
        if (GroundDetection() == false)
        {
            Vector3 direction = (playerPosition.position - transform.position).normalized;
            // Debug.DrawLine(transform.position, direction, Color.green, 0.1f);
            transform.LookAt(new Vector3(playerPosition.position.x, transform.position.y, playerPosition.position.z));

            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerPosition.position.x, 
            //PositionOffset().y, playerPosition.position.z), Time.deltaTime);
            characterController.Move(direction * 0.7f * Time.deltaTime);
        }
        else
        {
            Idle(tempPosition);
            PlayerDetector();
            enemyAnimation.Attack(false);
        }


    }


    private void DirecionHandler()
    {
        float distance = Vector3.Distance(transform.position, tempPosition.position);


        if (distance <= 0.4f)
        {


            if (tempPosition.position == InititalPosition.position)
            {
                tempPosition = finalPosition;
                transform.LookAt(new Vector3(tempPosition.position.x, transform.position.y, tempPosition.position.z));
                return;
            }
            if (tempPosition.position == finalPosition.position)
            {
                tempPosition = InititalPosition;

                transform.LookAt(new Vector3(tempPosition.position.x, transform.position.y, tempPosition.position.z));
                return;
            }




        }

    }

    bool GroundDetection()
    {
        Vector3 direction = -transform.position + areaScanner.position;
        RaycastHit hit;
        Ray ray = new Ray(transform.position, direction);

        bool groundInfront = false;

        if (Physics.Raycast(ray, out hit, 2f, enemyLayer))
        {
            if (hit.transform.CompareTag(staticString.Ground))
            {
                groundInfront = true;
            }

        }

        return groundInfront;



    }

    private void gravity()
    {

        if (Physics.CheckSphere(groundCheck.transform.position, 0.2f, groundLayer) && gravDirection < 0)
        {
            gravDirection = -2f;
        }

        gravDirection += absGravity * Time.deltaTime;

        characterController.Move(new Vector3(0, gravDirection, 0) * Time.deltaTime);


    }





}
