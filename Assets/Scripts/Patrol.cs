using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;


    private bool movingRight = true;
    public LayerMask siena;
    public Transform groundDetection;


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);


        RaycastHit2D wallinforight = Physics2D.Raycast(groundDetection.position, Vector2.right, 1f, siena);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);
        if (groundInfo.collider == false || wallinforight == true)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Health hp = col.gameObject.GetComponent<Health>();
        PlayerMovement pm = col.gameObject.GetComponent<PlayerMovement>();
        if (gameObject.tag == "smallenemy")
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
                hp.TakeDamage(1);
            }
        }


    }
}
