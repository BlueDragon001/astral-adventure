using System.Collections;
using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerAnimation playerAnimation;
    InputHandler inputHandler;

    public GameObject spirtObject;
    private GameObject spiritClone;

    int totalTime = 10;
    int timeElapsed;
    bool canBeAlive;
    Renderer[] renderers;

    public bool isAlive;

    public bool inputEnabled = true;

    public event Action PlayerDeath;

    void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        inputHandler = GetComponent<InputHandler>();
        renderers = GetComponentsInChildren<Renderer>();

    }


    void Update()
    {
        if (isAlive)
        {
            if(inputEnabled){
                wizardAndSpiritHandler(); 
            }
        }
        else
        {
            inputHandler.isAlive = false;
            playerAnimation.PlayerDeath(true);
            if(PlayerDeath != null){
                PlayerDeath();
            }
        }

    }

    public void wizardAndSpiritHandler()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (GameObject.FindGameObjectWithTag(staticString.spiritTag) == null && inputHandler.isAlive)
            {
                inputHandler.isAlive = false;
                playerAnimation.PlayerDeath(true);
                StartCoroutine(playerAnimation.SpiritTransformation1(false, renderers));
                spiritClone = Instantiate(spirtObject, gameObject.transform.position, gameObject.transform.rotation);
                var wizardMaterial = spirtObject.GetComponentInChildren<Renderer>().sharedMaterial;
                StartCoroutine(playerAnimation.SpiritTransformation2(true, wizardMaterial));
                StartCoroutine(deathTimer());

            }

            if (canBeAlive && totalTime > timeElapsed && GameObject.FindGameObjectWithTag(staticString.spiritTag) != null)
            {
                var wizardMaterial = spirtObject.GetComponentInChildren<Renderer>().sharedMaterial;
                StartCoroutine(playerAnimation.SpiritTransformation2(false, wizardMaterial));
                Destroy(spiritClone, 1);
                StartCoroutine(playerAnimation.SpiritTransformation1(true, renderers));
                playerAnimation.PlayerDeath(false);
                inputHandler.isAlive = true;
                canBeAlive = false;

            }

        }

        if (totalTime <= timeElapsed && !inputHandler.isAlive)
        {
            timeElapsed = 0;
            inputHandler.isAlive = false;
            var wizardMaterial = spirtObject.GetComponentInChildren<Renderer>().sharedMaterial;
            StartCoroutine(playerAnimation.SpiritTransformation2(false, wizardMaterial));
            Destroy(spiritClone, 1);
            StartCoroutine(playerAnimation.SpiritTransformation1(true, renderers));
        }

        

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(staticString.spiritTag))
        {
            canBeAlive = true;
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(staticString.spiritTag))
        {
            canBeAlive = false;
        }
    }
    IEnumerator deathTimer()
    {
        timeElapsed = 0;
        while (totalTime >= timeElapsed && !inputHandler.isAlive)
        {
            yield return new WaitForSeconds(1f);
            timeElapsed++;
        }
        timeElapsed = 0;
    }

}