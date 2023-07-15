using UnityEngine;

public class Attack : MonoBehaviour
{
   
    public GameObject fireIncantation;
    public GameObject fireAttackCircle;

    public GameObject attackPosition;

   

    GameObject tempMagic;


    private PlayerAnimation playerAnimation;

    public AudioSource magicSFX;

    void Start()
    {

        playerAnimation = GetComponent<PlayerAnimation>();

        float magicVolume = UnityCSharpExtension.InterpolateValue(staticMenuData.masterVolume * staticMenuData.sfxVolume, 0f, 100f * 100f);

        magicSFX.volume = magicVolume/2;
    }


    void Update()
    {

        //if (Input.GetMouseButtonDown(0) && tempMagic == null) EnemyAttack();
        if (tempMagic != null)
        {
            tempMagic.transform.position = attackPosition.transform.position;
            tempMagic.transform.rotation = transform.rotation;
        }
    }

    public void EnemyAttack()
    {
        if (tempMagic == null)
        {
            fireAttack();
            magicSFX.Play();
        }
    }

    void fireAttack()
    {
        playerAnimation.Attack();


        tempMagic = Instantiate(this.fireIncantation, attackPosition.transform.position,
         attackPosition.transform.rotation);


        foreach (Transform transform in tempMagic.GetComponentInChildren<Transform>())
        {
            ParticleSystem particleSystem = transform.GetComponent<ParticleSystem>();
            particleSystem.Play();
        }
        Destroy(tempMagic, 2f);

        GameObject attackCircle = Instantiate(fireAttackCircle, SpellInstLoc(), fireAttackCircle.transform.rotation);
        foreach (Transform transform in attackCircle.GetComponentInChildren<Transform>())
        {
            ParticleSystem particleSystem = transform.GetComponent<ParticleSystem>();
            particleSystem.Play();
        }
        Destroy(attackCircle, 1.2f);


    }

    private Vector3 SpellInstLoc()
    {
        Vector3 location = Vector3.zero;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector3 RayOrigin = Camera.main.ScreenToWorldPoint(mousePosition);
        Ray ray = new Ray(RayOrigin, Vector3.down);
        Vector3 direction = -(transform.position - RayOrigin);
        Debug.DrawLine(transform.position, direction.normalized * direction.magnitude * 20, Color.blue, 0.5f);
        Ray InititalRay = new Ray(transform.position, direction.normalized);
        if (Physics.Raycast(InititalRay, out RaycastHit initalHit, direction.magnitude))
        {
            if (!initalHit.transform.CompareTag(staticString.tagGate))
            {
                if (Physics.Raycast(ray, out RaycastHit hit, 30f))
                {
                    location = new Vector3(hit.point.x, hit.point.y, transform.position.z);
                }
            }
            Debug.DrawLine(transform.position, initalHit.transform.position, Color.green, 1f);
        }
        else
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 30f))
            {
                location = new Vector3(hit.point.x, hit.point.y, transform.position.z);
            }
        }





        // Vector3 direction = (transform.position - RayOrigin).normalized;
        // Ray InitialRay = new Ray(transform.position, direction);


        // if (Physics.Raycast(InitialRay, out RaycastHit initalHit, 100f, layer))
        // {

        //     if (!initalHit.transform.CompareTag("Gate"))
        //     {
        //         if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        //         {
        //             if (hit.transform.CompareTag("Ground"))
        //             {
        //                 location = new Vector3(hit.point.x, hit.point.y, transform.position.z);
        //             }

        //         }
        //         Debug.DrawLine(transform.position, initalHit.point, Color.red, 0.3f);
        //         Debug.Log("Tag: " + initalHit.transform.tag + "Name: " + initalHit.transform.name);
        //     }


        // }
        // else
        // {
        //     if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        //     {
        //         if (hit.transform.CompareTag("Ground"))
        //         {
        //             location = new Vector3(hit.point.x, hit.point.y, transform.position.z);

        //         }

        //         Debug.DrawLine(transform.position, hit.point, Color.red, 0.3f);
        //         Debug.Log("Tag: " + hit.transform.tag + "Name: " + hit.transform.name);

        //     }

        //     Debug.DrawLine(transform.position, hit.point, Color.red, 0.3f);

        //     Debug.Log("Hello World");
        // }

        return location;

    }

    // private Vector3 SpellInstLoc()
    // {
    //     Vector3 location = Vector3.zero;
    //     Vector3 mousePosition = Input.mousePosition;
    //     mousePosition.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);

    //     Vector3 RayOrigin = Camera.main.ScreenToWorldPoint(mousePosition);

    //     Ray InitialRay = new Ray(gameObject.transform.position, RayOrigin);
    //     float fireDistance = Vector3.Distance(gameObject.transform.position, RayOrigin);
    //     if (Physics.Raycast(InitialRay, out RaycastHit hit, fireDistance))
    //     {
    //         if (!hit.transform.CompareTag("Gate"))
    //         {
    //             Ray ray = new Ray(RayOrigin, Vector3.down);


    //             if (Physics.Raycast(ray, out RaycastHit hitFinal, 100f, layer))
    //             {
    //                 if (hitFinal.transform.CompareTag("Ground"))
    //                 {
    //                     location = new Vector3(hitFinal.point.x, hitFinal.point.y+0.1f, -2.224f);

    //                 }

    //             }


    //         }
    //     }
    //     else
    //     {
    //         Ray ray = new Ray(RayOrigin, Vector3.down);


    //             if (Physics.Raycast(ray, out RaycastHit hitFinal, 100f, layer))
    //             {
    //                 if (hitFinal.transform.CompareTag("Ground"))
    //                 {
    //                     location = new Vector3(hitFinal.point.x, hitFinal.point.y+0.1f, -2.224f);

    //                 }

    //             }

    //     }


    //     return location;

    // }
}
