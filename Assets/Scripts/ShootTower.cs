using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTower : MonoBehaviour
{
    public float Range;

    public Transform taikinys;

    bool Detected= false;

    Vector2 Direction;

    public GameObject pewpew;

    public float pewRate;

    private float nextPew = 0;

    public Transform ShootPoint;

    public float Force;

    public GameObject shootingpart;

    public Animator animator;




    void Update()
    {

        
        Vector2 targetPos = taikinys.position;

        Direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.CompareTag("Player"))
            {
                if (!Detected)
                {
                    Detected = true;
                }
            }
        }
        else
        {
            if (Detected)
            {
                shootingpart.transform.right = shootingpart.transform.right;
                Detected = false;
            }

        }
        if (Detected)
        {
            animator.SetBool("Detected", true); 
            shootingpart.transform.right = Direction * -1;
            if (Time.time > nextPew)
            {
                nextPew = Time.time + 1 / pewRate;
                shoot();
            }
            Detected = false;
        }
        else
        {
            animator.SetBool("Detected", false); 
        }
    }

    void shoot()
    {
        GameObject BulletIns = Instantiate(pewpew, ShootPoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }

}

