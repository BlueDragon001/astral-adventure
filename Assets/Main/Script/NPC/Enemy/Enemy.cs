using UnityEngine;

[RequireComponent(typeof(EnemyMovement), typeof(EnemyAnimation))]
public class Enemy : MonoBehaviour
{

    private EnemyMovement enemyMovement;
    private EnemyAnimation enemyAnimation;
    public bool isAlive = true;

    public float deathTime = 3f;




    void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAnimation = GetComponent<EnemyAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
           enemyMovement.Movement();
        }
        else
        {
            if (GetComponent<Animator>())
            {
                enemyAnimation.Death();
            }
            Destroy(this.gameObject, deathTime);
        }
    }





}
