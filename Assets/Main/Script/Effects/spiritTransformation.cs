using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiritTransformation : MonoBehaviour
{
    private ParticleSystem particle;
    public Transform targetPos;
    [Range(0, 10)]
    public int SpeedMult;
    public SkinnedMeshRenderer meshRenderer;
    private Material[] mat;

    [Range(0f, 1f)]
    public float setFloat = 1f;
    public bool isGlow;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();


        mat = meshRenderer.materials;
        Debug.Log(mat.Length);
    }

    // Update is called once per frame
    void Update()
    {
        ParticleTarget(targetPos.position);
        StartCoroutine(GlowActivator());
        

    }

    void ParticleTarget(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized * SpeedMult;

        var particleVel = particle.velocityOverLifetime;
        particleVel.x = direction.x;
        particleVel.y = direction.y;
        particleVel.z = direction.z;

    }

    void GlowPlayer(float amount)
    {

        foreach (Material material in mat)
        {
            material.SetFloat("_Amount_Dissolve", amount);

        }


    }

    IEnumerator GlowActivator()
    {
        if (isGlow)
        {
            if (setFloat > 0.1f)
            {
                setFloat -= 0.07f;
                GlowPlayer(setFloat);
                yield return new WaitForSeconds(1f);
            }
        }else{
            if (setFloat < 0.9f)
            {
                setFloat += 0.07f;
                GlowPlayer(setFloat);
                yield return new WaitForSeconds(1f);
            }
        }

    }
}
