using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fSpeed;
    public float fStrafeSpeed;
    public float fJumpForce;
    private float fFirstJumpForce;
    public bool isGrounded;
    public bool isRunning;
    public int nJumpForceCount;

    public Rigidbody rigidbody_Hips;
    public GameObject objHips;
    public Animator animator;

    public GameObject objPassWall;

    private void Start()
    {
        fFirstJumpForce = fJumpForce;
    }

    private void FixedUpdate()
    {
        Run();
        Move();

        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded)
            {
                rigidbody_Hips.AddForce(Vector3.up * fJumpForce, ForceMode.Impulse);
                isGrounded = false;
                animator.SetBool("Jump", true);
            }
        }
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Move", true);
                animator.SetBool("Run", true);
                isRunning = true;
                rigidbody_Hips.AddRelativeForce(Vector3.up * fSpeed * 1.5f);
            }
            else
            {
                animator.SetBool("Run", false);
                animator.SetBool("Move", true);
                rigidbody_Hips.AddRelativeForce(Vector3.up * fSpeed);
            }

            if (isRunning)
            {
                animator.SetBool("Move", true);
                animator.SetBool("Run", true);
                isRunning = true;
                rigidbody_Hips.AddRelativeForce(Vector3.up * fSpeed * 1.5f);
            }
            else
            {
                animator.SetBool("Run", false);
                animator.SetBool("Move", true);
                rigidbody_Hips.AddRelativeForce(Vector3.up * fSpeed);
            }
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Move", false);
            isRunning = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (isRunning)
            {
                //animator.SetBool("isLeft", true);
                rigidbody_Hips.AddForce(-rigidbody_Hips.transform.right * fStrafeSpeed * 1.5f);
            }
            else
            {
                //animator.SetBool("isLeft", true);
                //rigidbody_Hips.AddForce(-rigidbody_Hips.transform.right * fStrafeSpeed);
                rigidbody_Hips.AddRelativeForce(Vector3.forward * fSpeed);
            }
        }
        else
        {
            //animator.SetBool("isLeft", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (isRunning)
            {
                animator.SetBool("Move", true);
                rigidbody_Hips.AddRelativeForce(Vector3.down * fSpeed * 1.5f);
            }
            else
            {
                animator.SetBool("Move", true);
                rigidbody_Hips.AddRelativeForce(Vector3.down * fSpeed);
            }
        }
        else if (!Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Move", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (isRunning)
            {
                //animator.SetBool("isRight", true);
                rigidbody_Hips.AddForce(rigidbody_Hips.transform.right * fStrafeSpeed * 1.5f);
            }
            else
            {
                //animator.SetBool("isRight", true);
                //rigidbody_Hips.AddForce(rigidbody_Hips.transform.right * fStrafeSpeed);
                rigidbody_Hips.AddRelativeForce(Vector3.back * fSpeed);
            }
        }
        else
        {
            //animator.SetBool("isRight", false);
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

        //if (isRunning)
        //{
        //    objPassWall.GetComponent<BoxCollider>().enabled = false;
        //}
        //else
        //{
        //    objPassWall.GetComponent<BoxCollider>().enabled = true;
        //}
    }

    public void AddJumpForce()
    {
        if(nJumpForceCount <= 5)
        {
            nJumpForceCount++;
            fJumpForce += 100 * nJumpForceCount;
            Debug.Log("점프력 : " + fJumpForce);
        }

        rigidbody_Hips.AddForce(Vector3.up * fJumpForce);
        isGrounded = false;
    }

    public void ResetJumpForce()
    {
        animator.SetBool("Jump", false);
        fJumpForce = fFirstJumpForce;
        nJumpForceCount = 0;
    }
}
