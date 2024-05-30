using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveMentRigid : MonoBehaviour
{

    [Header("Move Horizontal")]
    [SerializeField]
    private float moveSpeed = 8;

    [Header("Move Vertical(Jump)")]
    [SerializeField]
    private float jumpForce = 10;
    [SerializeField]
    private float lowGravity = 2;
    [SerializeField]
    private float highGravity = 3;
    [SerializeField]
    private int maxJumpCount = 2;
    private int currentJumpCount;

    [Header("Collision")]
    [SerializeField]
    private LayerMask groundLayer;

    private bool isGrounded;
    private Vector2 footPosition;
    private Vector2 footArea;

    private Rigidbody2D rigid2D;
    private new Collider2D collider2D;

    public bool IsLonJump { set; get; } = false;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();    
    }
    private void FixedUpdate()
    {

        Bounds bounds = collider2D.bounds;

        footPosition = new Vector2(bounds.center.x, bounds.min.y);

        footArea = new Vector2((bounds.max.x - bounds.min.x) * 0.5f, 0.1f);

        isGrounded = Physics2D.OverlapBox(footPosition, footArea,0,groundLayer);

        if (isGrounded == true && rigid2D.velocity.y <= 0)
        {
            currentJumpCount = maxJumpCount;    
        }

        if (IsLonJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = lowGravity;
        }
        else
        {
            rigid2D.gravityScale = highGravity;
        }
    }



    public void MoveTo(float x)
    {
        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }
    public bool JumpTo()
    {
        if (currentJumpCount > 0)
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
            currentJumpCount--;
            return true;
        }
        return false;

    }
}
