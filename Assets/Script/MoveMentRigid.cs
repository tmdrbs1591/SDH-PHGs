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

    private Rigidbody2D rigid2D;

    public bool IsLonJump { set; get; } = false;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
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
        rigid2D.velocity = new Vector2(rigid2D.velocity.x,jumpForce);

        return true;
    }
}
