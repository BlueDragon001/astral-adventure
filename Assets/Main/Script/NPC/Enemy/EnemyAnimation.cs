using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        if (TryGetComponent<Animator>(out Animator anim)) animator = anim;
    }

    public void Attack(bool isPlayer)
    {
        if (animator != null) animator.SetBool(staticString.enemyAttack, isPlayer);
    }

    public void Death()
    {
        if(animator != null) animator.SetTrigger(staticString.EnemyDeath);
    }
}
