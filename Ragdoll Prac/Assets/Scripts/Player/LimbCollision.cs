using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    public PlayerController playerController;
    public TutorialManager tutorialManager;
    public Grab grab_R, grab_L;

    public int isLeftorRight;

    private bool isStartJumpTutorial;
    private bool isOnce;

    private void Start()
    {
        isStartJumpTutorial = false;
        isOnce = false;
    }

    private void Update()
    {
        if(tutorialManager != null)
        {
            if (tutorialManager.IsStartJumpTutorial() && !isOnce && playerController.isJump)
            {
                StartJumpTutorial();
                isOnce = true;
            }
        }
        CheckGround();
    }

    public void CheckGround()
    {
        RaycastHit hit_down, hit_Front;
        Vector3 down = transform.TransformDirection(Vector3.left);
        Vector3 front = transform.TransformDirection(new Vector3(-0.5f, 1, 0));
        Debug.DrawRay(transform.position, down * 0.25f, Color.red);
        Debug.DrawRay(transform.position, front * 0.3f, Color.red);

        // 튜토리얼 가이드에서만 쓰이는 점프 판정 (왼발에만)
        if (isStartJumpTutorial && isLeftorRight == 0)
        {
            if (Physics.Raycast(transform.position, down, out hit_down, 0.25f))
            {
                if (!playerController.isDelayToJump)
                {
                    if (hit_down.transform.CompareTag("Ground"))
                    {
                        if (isStartJumpTutorial && !playerController.isGrounded)
                        {
                            tutorialManager.EndJumpTutorial();
                            isStartJumpTutorial = false;
                            Debug.Log("점프 튜토리얼 완료");
                        }
                        InitJumpState();
                    }
                }
            }
        }
        
        // 튜토리얼 가이드 이후에 쓰는 점프판정 (양발)
        if (Physics.Raycast(transform.position, down, out hit_down, 0.25f) && !isStartJumpTutorial)
        {
            if (!playerController.isDelayToJump)
            {
                if (hit_down.transform.CompareTag("Ground"))
                {
                    InitJumpState();
                }
                else if (hit_down.transform.CompareTag("Wall"))
                {
                    InitJumpState();
                }
                else if (hit_down.transform.CompareTag("Item"))
                {
                    InitJumpState();
                }
                else if (hit_down.transform.CompareTag("Static"))
                {
                    Debug.Log("Static");
                    InitJumpState();
                }
                else if (hit_down.transform.CompareTag("MoveWall"))
                {
                    InitJumpState();
                }
                else if (hit_down.transform.CompareTag("Spring"))
                {
                    playerController.isGrounded = false;
                    playerController.isJump = false;
                    playerController.fRunSpeed = 2.0f;
                }
                
            }
        }
        else if(Physics.Raycast(transform.position, front, out hit_Front, 0.3f) && !isStartJumpTutorial)
        {
            if (!playerController.isDelayToJump)
            {
                if (hit_Front.transform.CompareTag("Ground") && (!grab_L.isCanGrab || !grab_R.isCanGrab))
                {
                    InitJumpState();
                }
                else if (hit_Front.transform.CompareTag("Wall"))
                {
                    InitJumpState();
                }
                else if (hit_Front.transform.CompareTag("Item"))
                {
                    InitJumpState();
                }
                else if (hit_Front.transform.CompareTag("Static"))
                {
                    Debug.Log("Static");
                    InitJumpState();
                }
                else if (hit_Front.transform.CompareTag("MoveWall"))
                {
                    InitJumpState();
                }
                else if (hit_Front.transform.CompareTag("Spring"))
                {
                    playerController.isGrounded = false;
                    playerController.isJump = false;
                    playerController.fRunSpeed = 2.0f;
                }
                
            }
        }
    }

    public void InitJumpState()
    {
        playerController.animator.SetBool("Jump", false);
        playerController.isGrounded = true;
        playerController.isJump = false;
        playerController.ResetJumpForce();
        playerController.fRunSpeed = 2.0f;
    }

    public void StartJumpTutorial()
    {
        isStartJumpTutorial = true;
    }
}
