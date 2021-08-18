using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spygliai : MonoBehaviour
{

    public int Damage;
    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerMovement pm = col.gameObject.GetComponent<PlayerMovement>();
        Health hp = col.gameObject.GetComponent<Health>();
        if (gameObject.tag == "spyglys")
        {
            if (col.gameObject.CompareTag("Player"))
            {
                pm.KBCout = pm.KBLen;

                if (pm.transform.position.x < transform.position.x)
                {
                    pm.KBRight = true;
                }
                else
                {
                    pm.KBRight = false;
                }
                Destroy(gameObject);
                hp.TakeDamage(Damage);
            }

        }

    }
}


