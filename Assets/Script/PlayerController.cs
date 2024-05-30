using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;
    private MoveMentRigid movement2D;

    private void Awake()
    {
        movement2D = GetComponent<MoveMentRigid>();
    }

    private void Update()
    {
        UpdateJump();
        UpdateMove();
    }

    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");

        //ÁÂ¿ìÀÌµ¿
        movement2D.MoveTo(x);
    }

    private void UpdateJump()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            movement2D.JumpTo();
        }
        else if (Input.GetKey(jumpKey))
        {
            movement2D.IsLonJump = true;
        }
        else if (Input.GetKeyUp(jumpKey))
        {
            movement2D.IsLonJump = false;
        }
    }
}
