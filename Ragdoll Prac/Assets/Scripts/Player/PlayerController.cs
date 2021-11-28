﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fSpeed;
    public float fStrafeSpeed;
    public float fJumpForce;
    public bool isGrounded;
    public bool isRunning;
    public int nJumpForceCount;

    public Rigidbody rigidbody_Hips;
    public GameObject objHips;
    public Animator animator;

    public GameObject objPassWall;

    private void FixedUpdate()
    {
        Run();
        Move();

        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded)
            {
                rigidbody_Hips.AddForce(new Vector3(0, fJumpForce, 0));
                isGrounded = false;
            }
        }
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //if (Input.GetKey(KeyCode.LeftShift))
            //{
            //    animator.SetBool("isWalk", true);
            //    animator.SetBool("isRun", true);
            //    isRunning = true;
            //    rigidbody_Hips.AddForce(rigidbody_Hips.transform.forward * fSpeed * 1.5f);
            //}
            //else
            //{
            //    animator.SetBool("isRun", false);
            //    animator.SetBool("isWalk", true);
            //    rigidbody_Hips.AddForce(rigidbody_Hips.transform.forward * fSpeed);
            //}

            if (isRunning)
            {
                animator.SetBool("isWalk", true);
                animator.SetBool("isRun", true);
                isRunning = true;
                rigidbody_Hips.AddForce(rigidbody_Hips.transform.forward * fSpeed * 1.5f);
            }
            else
            {
                animator.SetBool("isRun", false);
                animator.SetBool("isWalk", true);
                rigidbody_Hips.AddForce(rigidbody_Hips.transform.forward * fSpeed);
            }
        }
        else
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
            isRunning = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (isRunning)
            {
                animator.SetBool("isLeft", true);
                rigidbody_Hips.AddForce(-rigidbody_Hips.transform.right * fStrafeSpeed * 1.5f);
            }
            else
            {
                animator.SetBool("isLeft", true);
                rigidbody_Hips.AddForce(-rigidbody_Hips.transform.right * fStrafeSpeed);
            }
        }
        else
        {
            animator.SetBool("isLeft", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (isRunning)
            {
                animator.SetBool("isWalk", true);
                rigidbody_Hips.AddForce(-rigidbody_Hips.transform.forward * fSpeed * 1.5f);
            }
            else
            {
                animator.SetBool("isWalk", true);
                rigidbody_Hips.AddForce(-rigidbody_Hips.transform.forward * fSpeed);
            }
        }
        else if (!Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalk", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (isRunning)
            {
                animator.SetBool("isRight", true);
                rigidbody_Hips.AddForce(rigidbody_Hips.transform.right * fStrafeSpeed * 1.5f);
            }
            else
            {
                animator.SetBool("isRight", true);
                rigidbody_Hips.AddForce(rigidbody_Hips.transform.right * fStrafeSpeed);
            }
        }
        else
        {
            animator.SetBool("isRight", false);
        }
    }

    public void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        if (isRunning)
        {
            objPassWall.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            objPassWall.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void AddJumpForce()
    {
        if(nJumpForceCount <= 5)
        {
            nJumpForceCount++;
            fJumpForce += 2000 * nJumpForceCount;
            Debug.Log("점프력 : " + fJumpForce);
        }

        rigidbody_Hips.AddForce(new Vector3(0, fJumpForce, 0));
        isGrounded = false;
    }

    public void ResetJumpForce()
    {
        fJumpForce = 6000.0f;
        nJumpForceCount = 0;
    }
}