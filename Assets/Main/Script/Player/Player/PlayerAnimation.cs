
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

    }


    public void Locomotion(Vector3 direction)
    {
        if (direction.x != 0)
        {
            if (direction.x < 0)
            {
                transform.localRotation = Quaternion.Euler(0, (transform.rotation.y + 90), 0);
            }
            else if (direction.x > 0)
            {
                transform.localRotation = Quaternion.Euler(0, (transform.rotation.y + 270), 0);
            }
            animator.SetBool(staticString.aniMovement, true);
            animator.SetFloat(staticString.aniLocomotion, Mathf.Abs(direction.x));
        }
        else
        {
            animator.SetBool(staticString.aniMovement, false);
        }

        // Reset the position of the object to avoid any movement
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z));
    }




    public void JumpAnimation(bool isJumping)
    {
        animator.SetBool(staticString.aniJump, isJumping);
    }

    public void PlayerDeath(bool isTrue)
    {
        if (isTrue) animator.SetBool(staticString.aniDeath, true);
        else animator.SetBool(staticString.aniDeath, false);
    }

    public IEnumerator SpiritTransformation1(bool isAlive, Renderer[] renderers)
    {


        if (isAlive)
        {
            float T = 0;
            while (T < 1f)
            {
                T += Time.deltaTime / 0.5f;
                foreach (Renderer renderer in renderers)
                {
                    var materials = renderer.materials;
                    foreach (Material material in materials) material.SetFloat(staticString.AmountDissolve, Mathf.Lerp(0f, 1f, T));
                }

                yield return null;
            }
        }
        else
        {
            float T = 0;
            while (T < 1f)
            {
                T += Time.deltaTime / 0.5f; foreach (Renderer renderer in renderers)
                {
                    var materials = renderer.materials;
                    foreach (Material material in materials) material.SetFloat(staticString.AmountDissolve, Mathf.Lerp(1f, 0, T));
                }

                yield return null;
            }
        }


    }

    public IEnumerator SpiritTransformation2(bool isAlive, Material material)
    {


        if (!isAlive)
        {
            float T = 0;
            while (T < 1f)
            {
                T += Time.deltaTime / 0.5f;
                material.SetFloat(staticString.spiritAplhaClip, Mathf.Lerp(0f, 3f, T));
                yield return null;
            }
        }
        else
        {
            float T = 0;
            while (T < 1f)
            {
                T += Time.deltaTime / 0.5f;
                material.SetFloat(staticString.spiritAplhaClip, Mathf.Lerp(3f, 0f, T));
                yield return null;

                
            }
        }
    }

    public void Attack(){
        animator.SetTrigger(staticString.aniAttack);
    }



    // void Update(){
    //     Magic();
    // }
    // public void Magic(){
    //     gameObject.transform.localRotation = new Quaternion(2,5,7, 90);
    // }
}
