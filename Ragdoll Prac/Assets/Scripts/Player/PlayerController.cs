using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fSpeed;
    public float fStrafeSpeed;
    public float fRunSpeed;

    public float fJumpForce;
    private float fFirstJumpForce;
    public int nJumpForceCount;

    public bool isGrounded;
    public bool isRunning;
    public bool isDelayToJump;
    public bool isPlayerControl;

    public Rigidbody rigidbody_Hips;
    public GameObject objHips;

    public Animator animator;

    public AudioSource audioSource_Jump;

    public GameObject objPassWall;

    private void Start()
    {
        fFirstJumpForce = fJumpForce;
    }

    private void FixedUpdate()
    {
        if (isPlayerControl)
        {
            Run();
            Move();
        }
    }

    private void Update()
    {
        if (isPlayerControl)
        {
            Jump();
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
                rigidbody_Hips.AddRelativeForce(Vector3.up * fSpeed * fRunSpeed);
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
                rigidbody_Hips.AddRelativeForce(Vector3.up * fSpeed * fRunSpeed);
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
                rigidbody_Hips.AddRelativeForce(Vector3.forward * fStrafeSpeed * fRunSpeed);
            }
            else
            {
                //animator.SetBool("isLeft", true);
                //rigidbody_Hips.AddForce(-rigidbody_Hips.transform.right * fStrafeSpeed);
                rigidbody_Hips.AddRelativeForce(Vector3.forward * fStrafeSpeed);
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
                rigidbody_Hips.AddRelativeForce(Vector3.down * fSpeed * fRunSpeed);
            }
            else
            {
                animator.SetBool("Move", true);
                rigidbody_Hips.AddRelativeForce(Vector3.down * fSpeed * 2.0f);
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
                rigidbody_Hips.AddRelativeForce(Vector3.back * fStrafeSpeed * fRunSpeed);
            }
            else
            {
                //animator.SetBool("isRight", true);
                //rigidbody_Hips.AddForce(rigidbody_Hips.transform.right * fStrafeSpeed);
                rigidbody_Hips.AddRelativeForce(Vector3.back * fStrafeSpeed);
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

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                audioSource_Jump.Play();
                rigidbody_Hips.AddForce(Vector3.up * fJumpForce, ForceMode.Impulse);
                animator.SetBool("Jump", true);
                isGrounded = false;
                isDelayToJump = true;
                StartCoroutine(DelayToJump());
            }
        }
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

    IEnumerator DelayToJump()
    {
        Debug.Log("딜레이 시작");
        yield return new WaitForSeconds(0.1f);
        Debug.Log("딜레이 끝");
        isDelayToJump = false;
    }

    public void UnablePlayerControl()
    {
        isPlayerControl = false;
    }

    public void AblePlayerControl()
    {
        isPlayerControl = true;
    }
}
