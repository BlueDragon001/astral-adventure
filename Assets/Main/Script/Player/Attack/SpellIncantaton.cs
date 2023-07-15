using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellIncantaton : MonoBehaviour
{
    public GameObject fireCircle;
    public GameObject iceCircle;
    public bool isFireActive = true;


    void Start()
    {

    }

    void Update()
    {
        if(isFireActive) fireIncantion();
        else iceIncantation();

    }
    private void fireIncantion()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject spell = Instantiate(fireCircle, SpellInstLoc(), fireCircle.transform.rotation);
            foreach (Transform transform in spell.GetComponentInChildren<Transform>())
            {
                ParticleSystem particleSystem = transform.GetComponent<ParticleSystem>();
                particleSystem.Play();
            }
            Destroy(spell, 1.2f);


        }

    }

    private void iceIncantation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject spell = Instantiate(iceCircle, SpellInstLoc(), iceCircle.transform.rotation);
            foreach (Transform transform in spell.GetComponentInChildren<Transform>())
            {
                ParticleSystem particleSystem = transform.GetComponent<ParticleSystem>();
                particleSystem.Play();
            }
            Destroy(spell, 1.2f);


        }
    }

    private Vector3 SpellInstLoc()
    {
        Vector3 location = Vector3.zero;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector3 RayOrigin = Camera.main.ScreenToWorldPoint(mousePosition);
        Ray ray = new Ray(RayOrigin, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.transform.CompareTag("Ground"))
            {
                location = hit.point + Vector3.up * 0.5f;
            }

        }

        return location;

    }




}
