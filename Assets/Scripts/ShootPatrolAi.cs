using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPatrolAi : MonoBehaviour
{
    public float shootDistance;
    public Transform GanShoot;
    public GameObject bullet;
    public float Force;
    Vector2 Direction;
    public Transform taikinys;
    private float nextPew = 0;
    public float pewRate;
    public float pewRate1;



    public float speed;

    private bool movingRight = true;
    public LayerMask siena;
    public Transform groundDetection;

    void Update()
    {

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
        Vector2 targetPos = taikinys.position;

        Direction = targetPos - (Vector2)transform.position;

        RaycastHit2D shootGan = Physics2D.Raycast(transform.position, Direction, shootDistance);



        PlayerMovement pm = gameObject.GetComponent<PlayerMovement>();
        if (shootGan.collider?.gameObject.CompareTag("Player") ?? false)
        {
            GanShoot.transform.right = Direction * -1;
            if (Time.time > nextPew)
            {
                nextPew = Time.time + 1 / pewRate;
                shoot();
            }
        }
        else
        {
            GanShoot.transform.right = GanShoot.transform.right;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

    }
    public void shoot()
    {
        GameObject BulletIns = Instantiate(bullet, GanShoot.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, shootDistance);
    }
}
