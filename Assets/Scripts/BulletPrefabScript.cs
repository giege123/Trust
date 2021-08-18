using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefabScript : MonoBehaviour
{

    public float Speed = 20f;
    public Rigidbody2D rb;
    public int damage;


    void Start()
    {
        rb.velocity = transform.right * Speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Health priesas = hitInfo.GetComponent<Health>();
        if (priesas != null)
        {
            priesas.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
}
