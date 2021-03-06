using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothFactor;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }
}
