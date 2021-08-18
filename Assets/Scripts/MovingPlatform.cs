using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;

    private bool movingRight = true;
    public LayerMask siena;
    public Transform groundDetection;


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);


        RaycastHit2D wallinforight = Physics2D.Raycast(groundDetection.position, Vector2.right, 1f, siena);
        if (wallinforight == true)
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
}
