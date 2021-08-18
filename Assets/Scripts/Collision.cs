using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [Header("Layers")]

    public LayerMask groundLayers;
    public LayerMask wallLayers;
    public LayerMask platformLayers;
    public LayerMask slowLayers;

    [Header("Checks")]
    public Vector2 GroundOffset;
    public Vector2 RightOffset;
    public Vector2 LeftOffset;
    public Vector2 RightOffset2;
    public Vector2 LeftOffset2;
    public float CollisionRadius;
    public bool OnGround;
    public bool OnLeftWall;
    public bool OnRightWall;
    public int side;
    public bool OnSlow;
    public bool OnWall;
    public bool OnPlatform;
    public bool WalkingOnWall;
    public bool jumppad;

    void Update()
    {
        Checks();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + GroundOffset, CollisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + RightOffset, CollisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + LeftOffset, CollisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + RightOffset2, CollisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + LeftOffset2, CollisionRadius);

    }
    public void Checks()
    {

        OnGround = Physics2D.OverlapCircle((Vector2)transform.position + GroundOffset, CollisionRadius, groundLayers) || Physics2D.OverlapCircle((Vector2)transform.position + GroundOffset, CollisionRadius, wallLayers) || Physics2D.OverlapCircle((Vector2)transform.position + GroundOffset, CollisionRadius, platformLayers);
        OnWall = Physics2D.OverlapCircle((Vector2)transform.position + LeftOffset, CollisionRadius, wallLayers) ||
        Physics2D.OverlapCircle((Vector2)transform.position + RightOffset, CollisionRadius, wallLayers) || Physics2D.OverlapCircle((Vector2)transform.position + RightOffset2, CollisionRadius, wallLayers) || Physics2D.OverlapCircle((Vector2)transform.position + LeftOffset2, CollisionRadius, wallLayers);
        OnRightWall = Physics2D.OverlapCircle((Vector2)transform.position + RightOffset, CollisionRadius, wallLayers) || Physics2D.OverlapCircle((Vector2)transform.position + RightOffset2, CollisionRadius, wallLayers);
        OnLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + LeftOffset, CollisionRadius, wallLayers) || Physics2D.OverlapCircle((Vector2)transform.position + LeftOffset2, CollisionRadius, wallLayers);

    }
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("slow"))
        {
            OnSlow = true;
        }
        else OnSlow = false;
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("jumppad"))
        {
            jumppad = true;
        }
    }
    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("jumppad"))
        {
            jumppad = false;
        }

    }
}
