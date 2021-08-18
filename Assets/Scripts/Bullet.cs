using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(this.gameObject);
        if (coll == null)
        { return; }
        else
        {
            Health hp = coll.gameObject.GetComponent<Health>();
            hp.TakeDamage(1);
        }

    }
}
