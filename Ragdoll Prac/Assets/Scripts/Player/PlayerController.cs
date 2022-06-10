using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fSpeed;
    public float fStrafeSpeed;
    public float fRunSpeed;
    public float fMaxRunSpeed;
    public float fMaxWalkSpeed;

    public float fJumpForce;
    private float fFirstJumpForce;
    public int nJumpForceCount;

    public bool isGrounded;
    public bool isJump;
    public bool isRunning;
    public bool isDelayToJump;
    public bool isPlayerControl;
    public bool isEnterPassWall;

    public Rigidbody rigidbody_Hips;
    public GameObject objHips;

    public Animator animator;

    public AudioSource audioSource_Jump;

    public GameObject objPassWall;

    public PhysicMaterial physicMaterial_FootSlide;

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

            if (isRunning)
            {
                if (rigidbody_Hips.velocity.magnitude >= fMaxRunSpeed)
                {
                    rigidbody_Hips.velocity = rigidbody_Hips.velocity.normalized * fMaxRunSpeed;
                }
            }
            //else
            //{
            //    if (rigidbody_Hips.velocity.magnitude >= fMaxWalkSpeed)
            //    {
            //        rigidbody_Hips.velocity = rigidbody_Hips.velocity.normalized * fMaxWalkSpeed;
            //    }
            //}
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
                rigidbody_Hips.AddRelativeForce(Vector3.forward * fStrafeSpeed * fRunSpeed);
            }
            else
            {
                //animator.SetBool("isLeft", true);
                //rigidbody_Hips.AddForce(-rigidbody_Hips.transform.right * fStrafeSpeed);
                rigidbody_Hips.AddRelativeForce(Vector3.forward * fStrafeSpeed);
                animator.SetBool("SideMoveLeft", true);
            }
        }
        else
        {
            //animator.SetBool("isLeft", false);
            animator.SetBool("SideMoveLeft", false);
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
                animator.SetBool("SideMoveRight", true);
            }
        }
        else
        {
            //animator.SetBool("isRight", false);
            animator.SetBool("SideMoveRight", false);
        }
    }

    public void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
            if (animator.GetBool("SideMoveLeft") == true || animator.GetBool("SideMoveRight") == true)
            {
                physicMaterial_FootSlide.dynamicFriction = 0.15f;
            }
            else
            {
                physicMaterial_FootSlide.dynamicFriction = 0.5f;
            }
        }
        else
        {
            isRunning = false;
            if(animator.GetBool("Move") == true)
            {
                physicMaterial_FootSlide.dynamicFriction = 0.25f;
            }
            else if(animator.GetBool("SideMoveLeft") == true || animator.GetBool("SideMoveRight") == true)
            {
                physicMaterial_FootSlide.dynamicFriction = 0.15f;
            }
            else
            {
                physicMaterial_FootSlide.dynamicFriction = 0.5f;
            }
            
        }

        if(objPassWall != null)
        {
            if (isRunning || isEnterPassWall)
            {
                objPassWall.GetComponent<MeshCollider>().enabled = false;
            }
            else
            {
                objPassWall.GetComponent<MeshCollider>().enabled = true;
            }
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                audioSource_Jump.Play();
                rigidbody_Hips.AddForce(Vector3.up * fJumpForce, ForceMode.VelocityChange);
                animator.SetBool("Jump", true);
                isJump = true;
                isGrounded = false;
                isDelayToJump = true;
                StartCoroutine(DelayToJump());
                fRunSpeed = 1.0f;
            }
        }
    }

    public void AddJumpForce(float fJumpPower)
    {
        if (nJumpForceCount <= 4)
        {
            nJumpForceCount++;
            fJumpForce += fJumpPower * nJumpForceCount;
        }

        rigidbody_Hips.AddForce(Vector3.up * fJumpForce, ForceMode.VelocityChange);
        Debug.Log("점프력 : " + fJumpForce);
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

    public void StopRunAnimation()
    {
        animator.SetBool("Run", false);
    }

    public void StopMoveAnimation()
    {
        animator.SetBool("Move", false);
    }

    public void SetSpeedZero()
    {
        rigidbody_Hips.velocity = rigidbody_Hips.velocity.normalized;
    }

    public void EnterPassWall()
    {
        isEnterPassWall = true;
    }

    public void ExitPassWall()
    {
        isEnterPassWall = false;
    }
}
