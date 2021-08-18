using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public int Damagse = 1;
    public float radius = 10f;
    public Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();


    }
    public void Destruction()
    {
        anim.SetBool("Explode", true);

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D hitCollider in hitColliders)
        {
            Health hp = hitCollider.gameObject.GetComponent<Health>();
            hp?.TakeDamage(Damagse);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Health hp = gameObject.GetComponent<Health>();
            hp.TakeDamage(Damagse);
        }
    }

}
