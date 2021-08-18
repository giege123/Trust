using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puska : MonoBehaviour
{
    PlayerMovement pm;
    public GameObject bulletPref;
    public Transform Sautuvovieta;
    public float radius;
    float x;
    private void Awake()
    {
        pm = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        if (pm.side <= 0)
        {
            x = 180 * pm.side;
        }
        else
        {
            x = 0;
        }

        Quaternion angle = Quaternion.Euler(0, x, 0);
        GameObject newObject = Instantiate(bulletPref, Sautuvovieta.position, angle);  // instatiate the object

    }
}
